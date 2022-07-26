using FBE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FBE.ViewModels
{
    public class UsefulLinkCreate
    {
        [Required]
        public int Id { get; set; }
         
        [Required]
        public string Title { get; set; }
        [Required]
        public string Link { get; set; }
        public bool Enable { get; set; }
        public bool Deleted { get; set; } 
    }
}
