using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Program_Duzey
    {
        [Key]
        public int Prog_Duzey_Id { get; set; }
        [Required]
        public string Prog_Duzey { get; set; }
        public string Prog_Duzey_En { get; set; }
    }
}
