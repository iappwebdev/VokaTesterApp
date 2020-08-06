namespace VokaTester.Features.Lektionen.Dto
{
    public class LektionDto
    {
        public int Id { get; set; }

        public int Nr { get; set; }

        public string Name { get; set; }

        public string Titel { get; set; }

        public string SubTitel { get; set; }

        public string Inhalt { get; set; }

        public int Total { get; set; }

        public bool IsStarted { get; set; }
        
        public bool IsCompleted { get; set; }
    }
}
