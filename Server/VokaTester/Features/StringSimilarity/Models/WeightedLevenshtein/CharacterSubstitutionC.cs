namespace VokaTester.Features.StringSimilarity.Models.WeightedLevenshtein
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
