namespace VokaTester.Features.VokabelSpellCheck.Dto
{
    public class CheckVokabelRequest
    {
        public int VokabelId { get; set; }

        public string Answer { get; set; }

        public bool IsPrevVokabel { get; set; }
    }
}
