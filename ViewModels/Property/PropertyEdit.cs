using FBE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class PropertyEdit
    {
        [Required]
        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string TitleEn { get; set; }

        public string Link { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        public bool Deleted { get; set; }
        public bool Enable { get; set; }
        public int IconId { get; set; }
    
    public int SelectValue { get; set; }
    }
}
