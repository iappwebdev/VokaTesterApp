namespace VokaTester.Features.Vokabeln.Models
{
    public class VokabelListResponseModel
    {
        public int Id { get; set; }

        public int LektionId { get; set; }

        public string Frz { get; set; }

        public string Deu { get; set; }

        public string Phonetik { get; set; }

        public string ImageUrl { get; set; }
    }
}
