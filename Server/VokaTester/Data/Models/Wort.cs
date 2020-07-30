//namespace VokaTester.Data.Models
//{
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.Linq;
    
//    using static ValidationRules.General;
//    using static ValidationRules.Vokabel;

//    public class Wort
//    {
//        public int Id { get; set; }

//        [Required, MaxLength(MaxName)]
//        public string Sheet { get; set; }

//        [Required]
//        public int LektionNr { get; set; }

//        [Required, MaxLength(MaxName)]
//        public string LektionName { get; set; }

//        [Required, MaxLength(MaxName)]
//        public string BereichName { get; set; }

//        [Required, MaxLength(MaxWort)]
//        public string Frz { get; set; }

//        [Required, MaxLength(MaxPhonetik)]
//        public string Phonetik { get; set; }

//        [Required, MaxLength(MaxWort)]
//        public string Deu { get; set; }

//        [Required, MaxLength(MaxWort)]
//        public string Eng { get; set; }

//        [MaxLength(MaxWortart)]
//        public string Wortart { get; set; }

//        public List<string> Wortarten => this.Wortart.Split("|").ToList();
//    }
//}

