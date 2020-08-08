namespace VokaTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using static ValidationRules.General;

    public class Lektion
    {
        public int Id { get; set; }

        [Required, MaxLength(MaxNameOrTitel)]
        public string Key { get; set; }

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

        public Vokabel LastVokabel => this.Vokabeln.OrderBy(x => x.Id).Last();

        [NotMapped]
        public List<Bereich> Bereiche => this.Vokabeln.GroupBy(x => x.Bereich).Select(x => x.Key).OrderBy(x => x.Id).ToList();
        
        public int Total => this.Vokabeln.Count();
    }
}
