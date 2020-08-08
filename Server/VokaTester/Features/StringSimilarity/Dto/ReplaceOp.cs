namespace VokaTester.Features.StringSimilarity.Dto
{
    public class ReplaceOp
    {
        public string Target { get; set; }

        public string Source { get; set; }

        public int Pos { get; set; }

        public char? Prev { get; set; }

        public char Pattern { get; set; }

        public char? Next { get; set; }
    }
}
