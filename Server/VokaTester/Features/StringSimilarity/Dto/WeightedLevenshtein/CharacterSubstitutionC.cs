namespace VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein
{
    using static CharConstants;
    
    public class CharacterSubstitutionC : CharacterSubstitutionBase
    {
        public CharacterSubstitutionC(double costs)
            : base(VariationsC, costs)
        {
        }
    }
}
