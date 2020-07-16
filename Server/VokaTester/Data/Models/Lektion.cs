namespace VokaTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Lektion
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Fortschritt> Fortschritte { get; } = new List<Fortschritt>();

        public List<Vokabel> Vokabeln { get; } = new List<Vokabel>();
    }
}
