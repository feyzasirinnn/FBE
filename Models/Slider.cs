using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PhotoUrl1 { get; set; }

        [Required]
        public string PhotoUrl2 { get; set; }
        public string Title { get; set; } 

        public string Link { get; set; }

        public int Order { get; set; }

        public bool Enable { get; set; }

        public bool Deleted { get; set; }

        

        public Nullable<System.DateTime> CDate { get; set; }
    }
}
