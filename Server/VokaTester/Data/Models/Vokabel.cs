namespace VokaTester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using static ValidationRules.Vokabel;

    public class Vokabel
    {
        public int Id { get; set; }

        public int SheetNr { get; set; }

        [Required]
        public int LektionId { get; set; }

        public virtual Lektion Lektion { get; set; }

        public int BereichId { get; set; }

        public virtual Bereich Bereich { get; set; }

        public bool CaseSensitive { get; set; }

        [Required, MaxLength(MaxWort)]
        public string Frz { get; set; }

        [Required, MaxLength(MaxWort)]
        public string FrzSan { get; set; }

        [Required, MaxLength(MaxPhonetik)]
        public string Phonetik { get; set; }

        [Required, MaxLength(MaxWort)]
        public string Deu { get; set; }

        [Required, MaxLength(MaxWort)]
        public string DeuSan { get; set; }

        public bool HasChar_a => this.HasChar('a');

        public bool HasChar_à => this.HasChar('à');

        public bool HasChar_â => this.HasChar('â');

        public bool HasChar_c => this.HasChar('c');

        public bool HasChar_ç => this.HasChar('ç');
        
        public bool HasChar_e => this.HasChar('e');
        
        public bool HasChar_é => this.HasChar('é');

        public bool HasChar_è => this.HasChar('è');

        public bool HasChar_ê => this.HasChar('ê');

        public bool HasChar_ë => this.HasChar('ë');
        
        public bool HasChar_u => this.HasChar('u');
        
        public bool HasChar_û => this.HasChar('û');

        [MaxLength(MaxWortnetze)]
        public string Wortnetze { get; set; }

        public List<string> WortnetzList => this.Wortnetze.Trim().Split("|").ToList();

        [NotMapped]
        [MaxLength(MaxWortart)]
        public string Wortart { get; set; }

        public List<string> Wortarten => this.Wortart.Trim().Split("|").ToList();

        private bool HasChar(char c) => this.Frz.Contains(c);
    }
}
