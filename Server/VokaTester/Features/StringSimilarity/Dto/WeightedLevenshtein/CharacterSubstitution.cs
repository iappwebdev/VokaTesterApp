namespace VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein
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
