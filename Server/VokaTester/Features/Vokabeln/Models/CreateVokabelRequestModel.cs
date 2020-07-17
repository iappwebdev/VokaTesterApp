﻿namespace VokaTester.Features.Vokabeln.Models
{
    using System.ComponentModel.DataAnnotations;

    using static VokaTester.Data.Validation.Vokabel;

    public class CreateVokabelModel
    {
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
