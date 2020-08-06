namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.StringSimilarity;
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

        public async Task<CheckVokabelResponse> CheckSpellingAsync(int vokabelId, string frz, bool isPrevVokabel)
        {
            Vokabel vokabel = await this.dbContext.Vokabel.FindAsync(vokabelId);
            CheckVokabelResponse result = await this.CheckSpellingAsync(vokabel, frz);

            if (!isPrevVokabel)
            { 
                int res = await this.SaveFortschrittAsync(vokabel, result);
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

            if (this.generalizeStringService.HasArticle(result.TruthSan, out string articleTruth, out string wordTruth)
                && this.generalizeStringService.HasArticle(result.AnswerSan, out string articleAnswer, out string wordAnswer))
            {
                result.TruthArticle = articleTruth;
                result.TruthSan = wordTruth;
                result.AnswerArticle = articleAnswer;
                result.AnswerSan = wordAnswer;
            }

            if (this.IsCorrectAnswer(result.TruthSan, result.AnswerSan, vokabel.CaseSensitive))
            {

                result.IsCorrect = true;
            }
            else
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


        private async Task<int> SaveFortschrittAsync(Vokabel vokabel, CheckVokabelResponse result)
        {
            var testResult = new TestResult
            {
                UserId = this.currentUserService.GetId(),
                VokabelId = result.VokabelId,
                Truth = result.TruthSan,
                Answer = result.AnswerSan,
                IsCorrect = result.IsCorrect,
                IsSimilar = !result.IsCorrect && result.IsSimilar,
                IsArtikelFehler = result.IsArtikelFehler,
                IsSimilarAndArtikelFehler = !result.IsCorrect && result.IsSimilar && result.IsArtikelFehler,
                IsWrong = !result.IsCorrect && !result.IsSimilar
            };

            await this.dbContext.AddAsync(testResult);

            Fortschritt fortschritt =
                await this.dbContext
                   .Fortschritt
                   .FirstOrDefaultAsync(x => x.UserId == currentUserService.GetId() && x.LektionId == vokabel.LektionId);

            if (fortschritt == null)
            {
                fortschritt = new Fortschritt
                {
                    UserId = currentUserService.GetId(),
                    LektionId = vokabel.LektionId,
                    Durchlauf = 1
                };

                await this.dbContext.AddAsync(fortschritt);
            }

            if (result.IsCorrect
                && !result.IsArtikelFehler)
            {
                if (fortschritt.LetzteVokabelCorrectId.HasValue
                    && vokabel.Id == vokabel.Lektion.FirstVokabel.Id)
                {
                    fortschritt.Durchlauf++;
                }

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

        private bool IsNomen(string frz) =>
            frz.StartsWith("un ")
            || frz.StartsWith("une ")
            || frz.StartsWith("le ")
            || frz.StartsWith("la ");

    }
}
