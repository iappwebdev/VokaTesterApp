namespace VokaTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

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

        public virtual ICollection<Vokabel> Vokabeln { get; set; }
        
        public virtual ICollection<Fortschritt> Fortschritte { get; set; }

        public Vokabel FirstVokabel => this.Vokabeln.OrderBy(x => x.Id).First();
        
        public int Total => this.Vokabeln.Count();
    }
}
