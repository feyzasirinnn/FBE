using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Ens_Kurulu
    {
        [Key]
        public int Ens_Kurul_ID { get; set; }
        [Required]
        public string name { get; set; }
        public string surname { get; set; }
    }
}
