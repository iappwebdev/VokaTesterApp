namespace VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein
{
    using static CharConstants;
    
    public class CharacterSubstitutionO : CharacterSubstitutionBase
    {
        public CharacterSubstitutionO(double costs)
            : base(VariationsO, costs)
        {
        }
    }
}
