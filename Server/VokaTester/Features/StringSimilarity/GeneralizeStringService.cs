namespace VokaTester.Features.StringSimilarity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class GeneralizeStringService : IGeneralizeStringService
    {
        private readonly string charsToRemove = " ?&^$#@!()+-,:;<>’\'-_*";

        public string SanitizeString(string dirtyString)
        {
            string result = dirtyString;

            foreach (char c in this.charsToRemove)
            {
                result = result.Replace(c.ToString(), string.Empty);
            }

            return result;
        }
    }
}
