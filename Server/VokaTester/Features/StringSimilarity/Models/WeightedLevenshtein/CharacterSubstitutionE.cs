namespace VokaTester.Features.StringSimilarity.Models.WeightedLevenshtein
{
    using static CharConstants;
    
    public class CharacterSubstitutionE : CharacterSubstitutionBase
    {
        public CharacterSubstitutionE(double costs)
            : base(VariationsE, costs)
        {
        }
    }
}
