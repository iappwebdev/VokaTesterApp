namespace VokaTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ValidationRules.General;

    public class Lektion
    {
        public int Id { get; set; }

        public int Nr { get; set; }

        [Required, MaxLength(MaxNameOrTitel)]
        public string Name { get; set; }

        [MaxLength(MaxNameOrTitel)]
        public string Titel { get; set; }

        [MaxLength(MaxNameOrTitel)]
        public string SubTitel { get; set; }

        [Required, MaxLength(MaxNameOrTitel)]
        public string Inhalt { get; set; }

        //public List<Fortschritt> Fortschritte { get; } = new List<Fortschritt>();

        public List<Vokabel> Vokabeln { get; } = new List<Vokabel>();
    }
}
