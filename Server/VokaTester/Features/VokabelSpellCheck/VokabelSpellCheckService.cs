namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.VokabelSpellCheck.Dto;
    using VokaTester.Features.StringSimilarity;

    public class VokabelSpellCheckService : IVokabelSpellCheckService
    {
        private readonly VokaTesterDbContext dbContext;
        private readonly IGeneralizeStringService generalizeStringService;
        private readonly IStringSimilarityService stringSimilarityService;

        public VokabelSpellCheckService(
            VokaTesterDbContext dbContext,
            IGeneralizeStringService generalizeStringService,
            IStringSimilarityService stringSimilarityService)
        {
            this.dbContext = dbContext;
            this.generalizeStringService = generalizeStringService;
            this.stringSimilarityService = stringSimilarityService;
        }

        public async Task<CheckVokabelResponse> CheckSpelling(int vokabelId, string frz)
        {
            Vokabel vokabel = await this.dbContext.Vokabel.FindAsync(vokabelId);

            return await this.CheckSpelling(vokabel, frz);
        }


        public async Task<CheckVokabelResponse> CheckSpelling(Vokabel vokabel, string answer)
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

            await this.GetAdditionalAnswers(vokabel, result);

            if (this.IsCorrectAnswer(result.TruthSan, result.AnswerSan, vokabel.CaseSensitive))
            {
                result.IsCorrect = true;
            }
            else
            {
                result.SimilarityResult = this.stringSimilarityService.CheckSimilarity(truth, result.AnswerSan);
            }

            return result;
        }

        private async Task GetAdditionalAnswers(Vokabel vokabel, CheckVokabelResponse result)
        {
            List<Vokabel> similarVokabeln = await dbContext.Vokabel.Where(x => x.Deu == vokabel.Deu && x.Id != vokabel.Id).ToListAsync();

            if (similarVokabeln.Any())
            {
                result.HasMultipleCorrectAnswers = true;
                result.FurterCorrectVokabelIds = similarVokabeln.Select(x => x.Id).ToList();
                result.FurtherCorrectAnswers = similarVokabeln.Select(x => x.Frz).ToList();
                result.FurtherCorrectAnswersSan = result.FurtherCorrectAnswers.Select(x => this.generalizeStringService.SanitizeString(x)).ToList();
            }
        }

        public bool IsCorrectAnswer(string truth, string answer, bool isCaseSensitive)
            => isCaseSensitive ? truth == answer : truth.ToLower() == answer.ToLower();
    }
}
