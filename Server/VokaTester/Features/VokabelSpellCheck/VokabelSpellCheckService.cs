namespace VokaTester.Features.VokabelSpellCheck
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.StringSimilarity;
    using VokaTester.Features.StringSimilarity.Dto;
    using VokaTester.Features.VokabelSpellCheck.Dto;
    using VokaTester.Infrastructure.Services;

    public class VokabelSpellCheckService : IVokabelSpellCheckService
    {
        private readonly VokaTesterDbContext dbContext;
        private readonly ICurrentUserService currentUserService;
        private readonly IGeneralizeStringService generalizeStringService;
        private readonly IStringSimilarityService stringSimilarityService;

        public VokabelSpellCheckService(
            VokaTesterDbContext dbContext,
            ICurrentUserService currentUserService,
            IGeneralizeStringService generalizeStringService,
            IStringSimilarityService stringSimilarityService)
        {
            this.dbContext = dbContext;
            this.currentUserService = currentUserService;
            this.generalizeStringService = generalizeStringService;
            this.stringSimilarityService = stringSimilarityService;
        }

        public async Task<CheckVokabelResponse> CheckSpellingVokabelAsync(int vokabelId, string frz, bool isPrevVokabel, bool isForBereich = false)
        {
            Vokabel vokabel = await this.dbContext.Vokabel.FindAsync(vokabelId);
            CheckVokabelResponse result = await this.CheckSpellingAsync(vokabel, frz);
            int res1 = await SaveTestResult(vokabel, result);

            if (!isPrevVokabel)
            {
                // Result muss erwartet werden
                int res2 = await this.SaveFortschrittAsync(vokabel, result, isForBereich);

                if (res2 > 0)
                {
                    result.IsFortschrittSaved = true;
                }
            }

            return result;
        }

        private async Task<CheckVokabelResponse> CheckSpellingAsync(Vokabel vokabel, string answer)
        {
            string truth = vokabel.FrzSan;

            var result = new CheckVokabelResponse
            {
                VokabelId = vokabel.Id,
                Answer = answer,
                AnswerSan = this.generalizeStringService.SanitizeString(answer),
                Truth = truth,
                TruthSan = this.generalizeStringService.SanitizeString(truth)
            };

            await this.SetAdditionalAnswers(vokabel, result);

            ArticleInfo articleInfoTruth = this.generalizeStringService.GetArticleInfo(result.TruthSan);
            ArticleInfo articleInfoAnswer = this.generalizeStringService.GetArticleInfo(result.AnswerSan);

            if (articleInfoTruth.HasArticle)
            {
                result.TruthArticle = articleInfoTruth.Article;
                result.TruthSan = articleInfoTruth.Word;
                result.IsTruthArticleMasc = articleInfoTruth.IsMasc;
                result.IsTruthArticleFem = articleInfoTruth.IsFem;
            }

            if (articleInfoAnswer.HasArticle)
            {
                result.AnswerArticle = articleInfoAnswer.Article;
                result.AnswerSan = articleInfoAnswer.Word;
            }

            if (this.IsCorrectAnswer(result.TruthSan, result.AnswerSan, vokabel.CaseSensitive))
            {
                result.IsCorrect = true;
            }
            else if (!string.IsNullOrWhiteSpace(result.Answer))
            {
                result.SimilarityResult = this.stringSimilarityService.CheckSimilarity(result.TruthSan, result.AnswerSan);
            }

            return result;
        }

        private async Task SetAdditionalAnswers(Vokabel vokabel, CheckVokabelResponse result)
        {
            List<Vokabel> similarVokabeln = await dbContext.Vokabel.Where(x => x.Deu == vokabel.Deu && x.Id != vokabel.Id).ToListAsync();

            if (similarVokabeln.Any())
            {
                result.HasMultipleCorrectAnswers = true;
                result.FurtherCorrectVokabelIds = similarVokabeln.Select(x => x.Id).ToList();
                result.FurtherCorrectAnswers = similarVokabeln.Select(x => x.Frz).ToList();
                result.FurtherCorrectAnswersSan = result.FurtherCorrectAnswers.Select(x => this.generalizeStringService.SanitizeString(x)).ToList();
            }
        }

        private bool IsCorrectAnswer(string truth, string answer, bool isCaseSensitive)
            => isCaseSensitive ? truth == answer : truth.ToLower() == answer.ToLower();


        private async Task<int> SaveFortschrittAsync(Vokabel vokabel, CheckVokabelResponse result, bool isForBereich = false)
        {
            Fortschritt fortschritt = await this.GetFortschritt(vokabel, isForBereich);

            if (fortschritt == null)
            {
                fortschritt = new Fortschritt
                {
                    UserId = currentUserService.GetId(),
                    UserName = this.currentUserService.GetUserName(),
                    LektionId = vokabel.LektionId,
                    Durchlauf = 1,
                    BereichId = isForBereich ? vokabel.BereichId : (int?)null
                };

                await this.dbContext.AddAsync(fortschritt);
            }

            fortschritt.DateTestedLast = DateTime.Now;

            if (result.IsCorrect
                && !result.IsArtikelFehler)
            {
                if (!fortschritt.LetzteVokabelCorrectId.HasValue
                    || fortschritt.LetzteVokabelCorrectId.Value < vokabel.Id)
                {
                    fortschritt.LetzteVokabelCorrectId = vokabel.Id;
                }

                if (fortschritt.LetzteVokabelWrongId.HasValue
                    && fortschritt.LetzteVokabelWrongId.Value == vokabel.Id)
                {
                    fortschritt.LetzteVokabelWrongId = null;
                }
            }
            else
            {
                if (!fortschritt.LetzteVokabelWrongId.HasValue
                    || fortschritt.LetzteVokabelWrongId.Value > vokabel.Id)
                {
                    fortschritt.LetzteVokabelWrongId = vokabel.Id;
                }
            }

            return await this.dbContext.SaveChangesAsync();
        }

        private async Task<int> SaveTestResult(Vokabel vokabel, CheckVokabelResponse result)
        {
            var testResult = new TestResult
            {
                UserId = this.currentUserService.GetId(),
                UserName = this.currentUserService.GetUserName(),
                VokabelId = result.VokabelId,
                Question = vokabel.Deu,
                Truth = result.Truth,
                TruthSan = result.TruthSan,
                Answer = result.Answer,
                AnswerSan = result.AnswerSan,
                IsCorrect = result.IsCorrect,
                IsSimilar = !result.IsCorrect && result.IsSimilar,
                IsArtikelFehler = result.IsArtikelFehler,
                IsSimilarAndArtikelFehler = !result.IsCorrect && result.IsSimilar && result.IsArtikelFehler,
                IsWrong = result.IsWrong,
                DateTested = DateTime.Now
            };

            if (testResult.IsSimilar)
            {
                //testResult.ReplaceOps = JsonSerializer.Serialize(result.SimilarityResult.ReplaceOps);
            }

            await this.dbContext.AddAsync(testResult);

            return await this.dbContext.SaveChangesAsync();
        }

        private async Task<Fortschritt> GetFortschritt(Vokabel vokabel, bool isForBereich)
        {
            return isForBereich
                ? await this.dbContext
                    .Fortschritt
                    .FirstOrDefaultAsync(x =>
                        x.UserId == this.currentUserService.GetId()
                        && x.LektionId == vokabel.LektionId
                        && x.BereichId.HasValue
                        && x.BereichId.Value == vokabel.BereichId)
                : await this.dbContext
                   .Fortschritt
                   .FirstOrDefaultAsync(x =>
                        x.UserId == this.currentUserService.GetId()
                        && x.LektionId == vokabel.LektionId
                        && !x.BereichId.HasValue);
        }
    }
}
