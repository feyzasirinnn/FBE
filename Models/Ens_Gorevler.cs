using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Ens_Gorevler
    {
        [Key]
        public int EGorev_Id { get; set; }
        [Required]
        public string EGorev_Name { get; set; }
    }
}
