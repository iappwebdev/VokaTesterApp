namespace VokaTester.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TestResult
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int VokabelId { get; set; }

        public virtual Vokabel Vokabel { get; set; }

        [Required]
        public string Truth { get; set; }

        public string Answer { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsSimilar { get; set; }

        public bool IsArtikelFehler { get; set; }
        
        public bool IsSimilarAndArtikelFehler { get; set; }

        public bool IsWrong { get; set; }
    }
}
