namespace VokaTester.Features.StringSimilarity.Dto.WeightedLevenshtein
{
    using System.Collections.Generic;
    
    public class CharConstants
    {
        public const char A = 'a';
        public const char A_grave = 'à';
        public const char A_circonflexe = 'à';

        public static readonly char[] VariationsA = new[] { A, A_grave, A_circonflexe };

        public const char C = 'c';
        public const char C_cedille = 'ç';

        public static readonly char[] VariationsC = new[] { C, C_cedille };

        public const char E = 'e';
        public const char E_aigue = 'é';
        public const char E_grave = 'è';
        public const char E_trema = 'ë';
        public const char E_circonflexe = 'ê';

        public static readonly char[] VariationsE = new[] { E, E_aigue, E_grave, E_trema, E_circonflexe };

        public const char I = 'i';
        public const char I_circonflexe = 'î';

        public static readonly char[] VariationsI = new[] { I, I_circonflexe };

        public const char U = 'u';
        public const char U_circonflexe = 'û';

        public static readonly char[] VariationsU = new[] { U, U_circonflexe };

        public static readonly List<char[]> Variations = new List<char[]> { VariationsA, VariationsC, VariationsE, VariationsU };
    }
}