namespace VokaTester.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Validation.Vokabel;

    public class Vokabel
    {
        public int Id { get; set; }

        [Required]
        public int LektionId { get; set; }

        public Lektion Lektion { get; set; }

        [Required]
        [MaxLength(MaxWort)]
        public string Frz { get; set; }

        [Required]
        [MaxLength(MaxWort)]
        public string Deu { get; set; }

        [Required]
        [MaxLength(MaxPhonetik)]
        public string Phonetik { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
