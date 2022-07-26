using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Unvan
    {
        [Key]
        public int Unvan_Id { get; set; }

        [Required]
        public string Unvan_Name { get; set; }
    }
}
