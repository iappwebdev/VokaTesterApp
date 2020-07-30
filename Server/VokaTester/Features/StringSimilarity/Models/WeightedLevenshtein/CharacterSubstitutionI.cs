namespace VokaTester.Features.StringSimilarity.Models.WeightedLevenshtein
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
