namespace VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein
{
    using static CharConstants;
    
    public class CharacterSubstitutionI : CharacterSubstitutionBase
    {
        public CharacterSubstitutionI(double costs)
            : base(VariationsI, costs)
        {
        }
    }
}
