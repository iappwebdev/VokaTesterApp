namespace VokaTester.Features.VokabelSpellCheck
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.VokabelSpellCheck.Models;
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

        public async Task<VokabelSpellCheckResult> CheckSpelling(int vokabelId, string frz)
        {
            Vokabel vokabel = await this.dbContext.Vokabel.FindAsync(vokabelId);

            return await this.CheckSpelling(vokabel, frz);
        }


        public async Task<VokabelSpellCheckResult> CheckSpelling(Vokabel vokabel, string answer)
        {
            string truth = vokabel.Frz;

            var result = new VokabelSpellCheckResult
            {
                VokabelId = vokabel.Id,
                Answer = answer,
                AnswerSanitized = this.generalizeStringService.SanitizeString(answer),
                Truth = truth,
                TruthSanitized = this.generalizeStringService.SanitizeString(truth)
            };

            await this.GetAdditionalAnswers(vokabel, result);

            if (this.IsCorrectAnswer(result.TruthSanitized, result.AnswerSanitized))
            {
                result.IsCorrect = true;
            }
            else
            {
                result.SimilarityResult =  this.stringSimilarityService.CheckSimilarity(truth, result.AnswerSanitized);
            }

            return result;
        }

        private async Task GetAdditionalAnswers(Vokabel vokabel, VokabelSpellCheckResult result)
        {
            List<Vokabel> similarVokabeln = await dbContext.Vokabel.Where(x => x.Deu == vokabel.Deu && x.Id != vokabel.Id).ToListAsync();

            if (similarVokabeln.Any())
            {
                result.HasMultipleCorrectAnswers = true;
                result.FurtherCorrectAnswers = similarVokabeln.Select(x => x.Frz).ToList();
                result.FurtherCorrectAnswersSanitized = result.FurtherCorrectAnswers.Select(x => this.generalizeStringService.SanitizeString(x)).ToList();
            }
        }

        public bool IsCorrectAnswer(string truth, string answer) => truth == answer;
    }
}
