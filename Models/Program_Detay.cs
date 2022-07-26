using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Program_Detay
    {
        [Key]
        public int PD_Id { get; set; }
        [Required]
        public string Program_Detay_ { get; set; }
        public string Program_Detay_En { get; set; }
        public int ProgramId { get; set; }
        public virtual Programs Program { get; set; }
    }
}
