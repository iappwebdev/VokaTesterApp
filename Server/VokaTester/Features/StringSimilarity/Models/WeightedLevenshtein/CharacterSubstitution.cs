namespace VokaTester.Features.StringSimilarity.Models.WeightedLevenshtein
{
    using static CharConstants;
    
    public class CharacterSubstitution : CharacterSubstitutionBase
    {
        public CharacterSubstitution(double costs)
            : base (Variations, costs)
        {
        }
    }
}
