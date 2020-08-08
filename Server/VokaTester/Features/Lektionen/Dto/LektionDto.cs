namespace VokaTester.Features.Lektionen.Dto
{
    using System.Collections.Generic;

    public class LektionDto
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Titel { get; set; }

        public string SubTitel { get; set; }

        public string Inhalt { get; set; }
        
        public int Position { get; set; }

        public int Total { get; set; }

        public bool IsStarted { get; set; }

        public bool IsCompleted { get; set; }

        public List<BereichDto> Bereiche { get; set; }
    }
}
