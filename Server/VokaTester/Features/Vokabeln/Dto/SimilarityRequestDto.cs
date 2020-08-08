namespace VokaTester.Features.Vokabeln.Dto
{
    public class SimilarityRequestDto
    {
        public int VokabelId { get; set; }

        public char? Prev { get; set; }

        public char Pattern { get; set; }

        public char? Next { get; set; }
    }
}
