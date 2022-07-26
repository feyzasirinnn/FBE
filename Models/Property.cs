using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string TitleEn { get; set; }

        public string Link { get; set; }

        public string PhotoUrl { get; set; } 

        public bool Enable { get; set; }

        public bool Deleted { get; set; }

        public string Target { get; set; }

        public int? Child { get; set; }


    }
}
