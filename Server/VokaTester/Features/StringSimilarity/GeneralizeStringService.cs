namespace VokaTester.Features.StringSimilarity
{
    using System.Linq;
    using System.Text.RegularExpressions;

    public class GeneralizeStringService : IGeneralizeStringService
    {
        private readonly string charsToRemove = "?&^$#@!()+:;<>_*";
        private readonly Regex regexBlanks = new Regex("[ ]{2,}", RegexOptions.None);
        private readonly Regex regexArticle = new Regex("(un|une|le|la)", RegexOptions.None);

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

        public bool HasArticle(string frz, out string article, out string word)
        {
            article = string.Empty;
            word = frz;
            int idxBlank = frz.IndexOf(' ');

            if (string.IsNullOrWhiteSpace(frz) || idxBlank < 0)
            {
                return false;
            }

            string possibleArticle = frz.Substring(0, idxBlank);
            bool hasArticle = this.regexArticle.IsMatch(possibleArticle);

            if (hasArticle)
            {
                article = possibleArticle;
                word = frz.Substring(idxBlank + 1);
            }
            else
            {
                word = frz;
            }

            return hasArticle;
        }
    }
}
