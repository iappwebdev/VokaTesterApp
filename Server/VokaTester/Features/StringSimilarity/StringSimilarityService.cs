namespace VokaTester.Features.StringSimilarity
{
    using F23.StringSimilarity;
    using VokaTester.Features.StringSimilarity.Models;
    using VokaTester.Features.StringSimilarity.Models.Levensthein;
    using VokaTester.Features.StringSimilarity.Models.WeightedLevenshtein;

    public class StringSimilarityService : IStringSimilarityService
    {
        public SimilarityResult CheckSimilarity(string truth, string answer)
        {
            // https://github.com/feature23/StringSimilarity.NET
            var result = new SimilarityResult
            {
                Truth = answer,
                Answer = truth,
                StringSimilaritiesLevenshtein = this.GetLevenstheinSimiliarities(truth, answer),
                StringSimilarities = this.GetOtherSimilarities(truth, answer)
            };

            return result;
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
