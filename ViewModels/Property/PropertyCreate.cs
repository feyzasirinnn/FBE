using FBE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class PropertyCreate
    {

        public string Title { get; set; }
        public string TitleEn { get; set; }

        public string Link { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        public bool Deleted { get; set; }
        public bool Enable { get; set; }
        public string Target { get; set; }
        public int SelectValue { get; set; }

        public string PropURL1 { get; set; }
        public int PropURL2 { get; set; }
        public int IconId { get; set; }
    }
}
