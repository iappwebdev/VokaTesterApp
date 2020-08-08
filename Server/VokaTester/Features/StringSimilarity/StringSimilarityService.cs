namespace VokaTester.Features.StringSimilarity
{
    using System.Collections.Generic;
    using System.Linq;
    using F23.StringSimilarity;
    using VokaTester.Features.StringSimilarity.Dto;
    using VokaTester.Features.StringSimilarity.Dto.Levensthein;
    using VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein;

    public class StringSimilarityService : IStringSimilarityService
    {
        private readonly IGeneralizeStringService generalizeStringService;

        public StringSimilarityService(
            IGeneralizeStringService generalizeStringService)
        {
            this.generalizeStringService = generalizeStringService;
        }

        public SimilarityResult CheckSimilarity(string truth, string answer)
        {
            // https://github.com/feature23/StringSimilarity.NET
            var result = new SimilarityResult
            {
                Truth = this.generalizeStringService.SanitizeString(truth),
                Answer = this.generalizeStringService.SanitizeString(answer),
                StringSimilaritiesLevenshtein = this.GetLevenstheinSimiliarities(truth, answer),
                StringSimilaritiesOthers = this.GetOtherSimilarities(truth, answer)
            };

            this.SetEditOperations(result);

            return result;
        }

        private void SetEditOperations(SimilarityResult result)
        {
            result.EditOperationsLeventhein = new List<KeyValuePair<int, char>>();
            result.ReplaceOps = new List<ReplaceOp>();

            List<EditOperation> operations = result.StringSimilaritiesLevenshtein.LevenstheinMethod;
            int idx = 0;

            foreach (EditOperation op in operations)
            {
                if (op.Operation == EditOperationKind.Edit)
                {
                    bool interestedInSourceValue = CharConstants.FrenchChars.Contains(op.OldValue) && !CharConstants.FrenchChars.Contains(op.Value);
                    char charInterested = interestedInSourceValue ? op.OldValue : op.Value;
                    string stringInterested = interestedInSourceValue ? result.Answer : result.Truth;

                    result.EditOperationsLeventhein.Add(new KeyValuePair<int, char>(idx, charInterested));
                    result.ReplaceOps.Add(new ReplaceOp
                    {
                        Target = result.Truth,
                        Source = result.Answer,
                        Pos = idx,
                        Pattern = charInterested,
                        Prev = this.generalizeStringService.GetPrevChar(stringInterested, idx),
                        Next = this.generalizeStringService.GetNextChar(stringInterested, idx)
                    });
                }

                if (op.Operation != EditOperationKind.Remove) { 
                    idx++;
                }
            }
        }

        private StringSimilaritiesLevenshtein GetLevenstheinSimiliarities(string truth, string answer)
        {
            var stringSimilaritiesLevenshtein = new StringSimilaritiesLevenshtein();

            // Levenshtein -> StringDistance
            Levenshtein l = new Levenshtein();
            stringSimilaritiesLevenshtein.Dist_Levenshtein = l.Distance(truth, answer);

            // Normalized Levenshtein -> Normalized StringDistance 
            var nl = new NormalizedLevenshtein();
            stringSimilaritiesLevenshtein.Dist_Normalized_Levenshtein = nl.Distance(truth, answer);
            stringSimilaritiesLevenshtein.Similiarity_NormalizedLevenshtein = nl.Similarity(truth, answer);

            double costs = 0.05;

            // Weighted Levenshtein -> Weighted StringDistance
            var wl = new MyWeightedLevenshtein(new CharacterSubstitution(costs));
            stringSimilaritiesLevenshtein.Dist_Weighted = wl.Distance(truth, answer);

            // Weighted Levenshtein -> Weighted StringDistance
            var wlA = new MyWeightedLevenshtein(new CharacterSubstitutionA(costs));
            stringSimilaritiesLevenshtein.Dist_WeightedA = wlA.Distance(truth, answer);

            // Weighted Levenshtein -> Weighted StringDistance
            var wlC = new MyWeightedLevenshtein(new CharacterSubstitutionC(costs));
            stringSimilaritiesLevenshtein.Dist_WeightedC = wlC.Distance(truth, answer);

            // Weighted Levenshtein -> Weighted StringDistance
            var wlE = new MyWeightedLevenshtein(new CharacterSubstitutionE(costs));
            stringSimilaritiesLevenshtein.Dist_WeightedE = wlE.Distance(truth, answer);

            // Weighted Levenshtein -> Weighted StringDistance
            var wlI = new MyWeightedLevenshtein(new CharacterSubstitutionI(costs));
            stringSimilaritiesLevenshtein.Dist_WeightedI = wlI.Distance(truth, answer);

            // Weighted Levenshtein -> Weighted StringDistance
            var wlU = new MyWeightedLevenshtein(new CharacterSubstitutionU(costs));
            stringSimilaritiesLevenshtein.Dist_WeightedU = wlU.Distance(truth, answer);

            var lm = new SimpleLevenstheinMethod
            {
                Target = truth,
                Source = answer,
                EditCost = 0.5,
                CopyCost = 0
            };

            stringSimilaritiesLevenshtein.LevenstheinMethod = lm.GetEditSequence();

            return stringSimilaritiesLevenshtein;
        }

        private StringSimilarities GetOtherSimilarities(string truth, string answer)
        {
            var stringSimilarities = new StringSimilarities();

            // Damerau-Levenshtein -> StringDistance (mit Operation Zeichen vertauschen)
            var d = new Damerau();
            stringSimilarities.Dist_Metric_Damerau = d.Distance(truth, answer);

            // Jaro-Winkler -> Normalized StringDistance (short Names + Typos)
            var jw = new JaroWinkler();
            stringSimilarities.Distance_JaroWinkler = jw.Distance(truth, answer);
            stringSimilarities.Similarity_JaroWinkler = jw.Similarity(truth, answer);

            // Longest Common Subsequence -> StringDistance
            var lcs = new LongestCommonSubsequence();
            stringSimilarities.LongestCommonSubsequence = lcs.Distance(truth, answer);
            stringSimilarities.Subsequence_LongestCommonSubsequenceLength = lcs.Length(truth, answer);


            // N-Gram Normalized -> StringDistance
            var ngram = new NGram(2);
            stringSimilarities.Dist_norm_NGram = ngram.Distance(truth, answer);

            // OptimalStringAlignment -> StringDistance
            var osa = new OptimalStringAlignment();
            stringSimilarities.OptimalStringAlignment = osa.Distance(truth, answer);
            return stringSimilarities;
        }
    }
}
