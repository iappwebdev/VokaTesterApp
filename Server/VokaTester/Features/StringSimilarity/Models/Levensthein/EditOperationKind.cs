namespace VokaTester.Features.StringSimilarity.Models.Levensthein
{
    public enum EditOperationKind : byte
    {
        /// <summary>
        /// Copy existing character
        /// </summary>
        Copy = 1,

        /// <summary>
        /// Change existing character to new character
        /// </summary>
        Edit,

        /// <summary>
        /// Add new character
        /// </summary>
        Insert,

        /// <summary>
        /// Delete existing character
        /// </summary>
        Remove,
    }
}
