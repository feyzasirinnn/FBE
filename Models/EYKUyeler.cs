using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class EYKUyeler
    {
        [Key]
        public int eyk_uyeler_ID { get; set; }
        [Required]
        public Akademik_Kadro Akademik_Kadro { get; set; }
        public EABD EABD { get; set; }
        public Ens_Gorevler Ens_Gorevler { get; set; }
        public Unvan Unvan { get; set; }
        [Required]
        public Boolean isActive { get; set; }
        
    }
}
