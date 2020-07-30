namespace VokaTester.Features.Vokabeln.Models
{
    public class VokabelListingServiceModel
    {
        public int Id { get; set; }

        public int LektionId { get; set; }

        public int BereichId { get; set; }
        
        public bool CaseSensitive { get; set; }

        public string Frz { get; set; }
        
        public string FrzSan { get; internal set; }

        public string Phonetik { get; set; }

        public string Deu { get; set; }
    }
}
