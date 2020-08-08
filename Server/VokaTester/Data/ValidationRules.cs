namespace VokaTester.Data
{
    public class ValidationRules
    {
        public class General
        {
            public const int MaxNameOrTitel = 100;
        }

        public class Vokabel
        {
            public const int MaxWort = 500;

            public const int MaxPhonetik = 100;

            //public const int MaxWortnetze = 200;
            
            public const int MaxWortart = 200;
        }
    }
}
