namespace VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein
{
    using System.Collections.Generic;
    using System.Linq;

    public class CharConstants
    {
        public const char A = 'a';
        public const char A_grave = 'à';
        public const char A_circonflexe = 'â';

        public static readonly char[] VariationsA = new[] { A, A_grave, A_circonflexe };

        public const char C = 'c';
        public const char C_cedille = 'ç';

        public static readonly char[] VariationsC = new[] { C, C_cedille };

        public const char E = 'e';
        public const char E_aigue = 'é';
        public const char E_grave = 'è';
        public const char E_circonflexe = 'ê';
        public const char E_trema = 'ë';

        public static readonly char[] VariationsE = new[] { E, E_aigue, E_grave, E_trema, E_circonflexe };

        public const char I = 'i';
        public const char I_circonflexe = 'î';
        public const char I_trema = 'ï';

        public static readonly char[] VariationsI = new[] { I, I_circonflexe, I_trema };

        public const char O = 'o';
        public const char O_circonflexe = 'ô';

        public static readonly char[] VariationsO = new[] { O, O_circonflexe };

        public const char U = 'u';
        public const char U_grave = 'ù';
        public const char U_circonflexe = 'û';

        public static readonly char[] VariationsU = new[] { U, U_grave, U_circonflexe };

        public static readonly List<char[]> Variations = new List<char[]> { VariationsA, VariationsC, VariationsE, VariationsI, VariationsO, VariationsU };

        public static readonly List<char> GermanChars = new List<char> { A, C, E, I, U };

        public static List<char> FrenchChars => Variations.SelectMany(x => x).Where(x => GermanChars.Contains(x) == false).ToList();
    }
}