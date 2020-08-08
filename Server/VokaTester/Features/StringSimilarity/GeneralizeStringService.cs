namespace VokaTester.Features.StringSimilarity
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using VokaTester.Features.StringSimilarity.Dto;

    public class GeneralizeStringService : IGeneralizeStringService
    {
        private readonly string charsToRemove = "?&^$#@!()+:,;<>_*";
        private readonly Regex regexBlanks = new Regex("[ ]{2,}", RegexOptions.None);
        private readonly string[] articlesMasc = new []{ "un", "le" };
        private readonly string[] articlesFem = new []{ "une", "la" };

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

        public ArticleInfo GetArticleInfo(string frz)
        {
            var res = new ArticleInfo
            {
                Word = frz
            };

            int idxBlank = frz.IndexOf(' ');

            if (string.IsNullOrWhiteSpace(frz) || idxBlank < 0)
            {
                return res;
            }

            res.PossibleArticle = frz.Substring(0, idxBlank);
            res.IsMasc = this.articlesMasc.Contains(res.PossibleArticle);
            res.IsFem = this.articlesFem.Contains(res.PossibleArticle);

            if (res.HasArticle)
            {
                res.Article = res.PossibleArticle;
                res.Word = frz.Substring(idxBlank + 1);
            }

            return res;
        }

        public string GetSurroundingString(string value, int pos)
        {
            if (value.Length <= 2)
            {
                return value;
            }

            if (pos >= value.Length)
            {
                pos = value.Length - 1;
            }

            int startPos = pos > 0 ? pos - 1 : pos;
            int length = (pos == 0 || pos == value.Length - 1) ? 2 : 3;

            return value.Substring(startPos, length);
        }

        public char? GetPrevChar(string value, int pos)
        {
            return
                value.Length <= 1
                || pos <= 0
                ? null
                : (char?)value[pos - 1];
        }

        public char? GetNextChar(string value, int pos)
        {
            return
                value.Length <= 1
                || pos >= value.Length - 1
                ? null
                : (char?)value[pos + 1];
        }
    }
}
