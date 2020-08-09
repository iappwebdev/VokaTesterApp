namespace VokaTester.Features.Lektionen.Dto
{
    public class BereichDto
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string LektionName { get; set; }

        public string Abkuerzung { get; set; }

        public string Name { get; set; }
        
        public int Position { get; set; }

        public int Total { get; set; }

        public int FirstVokabelId { get; set; }

        public int LastVokabelId { get; set; }

        public bool IsStarted { get; set; }
        
        public bool IsCompleted { get; set; }
    }
}
