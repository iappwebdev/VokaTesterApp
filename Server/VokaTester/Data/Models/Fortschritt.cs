namespace VokaTester.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Fortschritt
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
        
        [Required]
        public string UserName { get; set; }

        public int LektionId { get; set; }

        public virtual Lektion Lektion { get; set; }

        public int? BereichId { get; set; }

        public virtual Bereich Bereich { get; set; }

        public int Durchlauf { get; set; }

        public int? LetzteVokabelCorrectId { get; set; }

        public virtual Vokabel LetzteVokabelCorrect { get; set; }

        public int? LetzteVokabelWrongId { get; set; }

        public virtual Vokabel LetzteVokabelWrong { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }

        [Required]
        public DateTime DateTestedLast { get; set; }
    }
}
