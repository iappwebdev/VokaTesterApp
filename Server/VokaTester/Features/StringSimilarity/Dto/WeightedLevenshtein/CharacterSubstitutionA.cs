namespace VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein
{
    using static CharConstants;

    public class CharacterSubstitutionA : CharacterSubstitutionBase
    {
        public CharacterSubstitutionA(double costs)
            : base (VariationsA, costs)
        {
        }
    }
}
