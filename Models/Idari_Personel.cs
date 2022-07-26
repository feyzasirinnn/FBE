using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Idari_Personel
    {
        [Key]
        public int idari_Id { get; set; }
        [Required]
        public string ad { get; set; }
        public string soyad { get; set; }
        public int Sicil_No { get; set; }
        [ForeignKey("Sicil_No")]
        public Akademik_Kadro Akademik_Kadro { get; set; }
        [Required]

        public int Unvan_Id { get; set; }
        [ForeignKey("Unvan_Id")]
        public Unvan Unvan { get; set; }
        [Required]
        public int EGorev_Id { get; set; }
        [ForeignKey("EGorev_Id")]
        public Ens_Gorevler Ens_Gorevler { get; set; }
        [Required]
        public string phone { get; set; }

        public string photo{ get; set; }
        
    }
}
