namespace VokaTester.Features.Vokabeln.Dto
{
    public class VokabelDto
    {
        public int Id { get; set; }

        public int LektionId { get; set; }

        public string LektionName { get; set; }
        
        public int BereichId { get; set; }
        
        public string BereichName { get; set; }

        public bool CaseSensitive { get; set; }

        public string Frz { get; set; }
        
        public string FrzSan { get; internal set; }

        public string Phonetik { get; set; }

        public string Deu { get; set; }
        
        public string DeuSan { get; set; }
    }
}
