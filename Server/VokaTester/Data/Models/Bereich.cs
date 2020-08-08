namespace VokaTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ValidationRules.General;

    public class Bereich
    {
        public int Id { get; set; }

        [Required, MaxLength(MaxNameOrTitel)]
        public string Key { get; set; }

        [Required, MaxLength(MaxNameOrTitel)]
        public string Abkuerzung { get; set; }

        [Required, MaxLength(MaxNameOrTitel)]
        public string Name { get; set; }

        public virtual ICollection<Vokabel> Vokabeln { get; set; }
    }
}