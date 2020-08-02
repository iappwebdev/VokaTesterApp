namespace VokaTester.Features.StringSimilarity
{
    using System.Text.RegularExpressions;

    public class GeneralizeStringService : IGeneralizeStringService
    {
        private readonly string charsToRemove = "?&^$#@!()+-,:;<>’\'-_*";
        private readonly Regex regexBlanks = new Regex("[ ]{2,}", RegexOptions.None);

        public string SanitizeString(string dirtyString)
        {
            if (dirtyString == null)
            {
                return string.Empty;
            }

            string result = this.regexBlanks.Replace(dirtyString, " ").Trim();

            foreach (char c in this.charsToRemove)
            {
                result = result.Replace(c.ToString(), string.Empty);
            }

            return result;
        }
    }
}
