namespace VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein
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
