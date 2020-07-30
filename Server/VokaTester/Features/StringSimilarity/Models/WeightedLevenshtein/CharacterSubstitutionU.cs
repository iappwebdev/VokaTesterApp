namespace VokaTester.Features.StringSimilarity.Models.WeightedLevenshtein
{
    using static CharConstants;
    
    public class CharacterSubstitutionU : CharacterSubstitutionBase
    {
        public CharacterSubstitutionU(double costs)
            : base(VariationsU, costs)
        {
        }
    }
}
