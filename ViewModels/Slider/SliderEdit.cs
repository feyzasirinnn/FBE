using FBE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class SliderEdit
    {
        [Required]
        [DisplayName("Slider Id")]
        public int Id { get; set; }
          
        [Required]
        [DisplayName("Fotoğraf Linki")]
        public string PhotoUrl { get; set; }

        [Required]
        [DisplayName("Slayt Başlığı")]
        public string Title { get; set; }

        [DisplayName("Yönlendirme Linki")]
        public string Link { get; set; }

        [DisplayName("Sıra")]
        public int Order { get; set; }

        public bool Enable { get; set; }

        public bool Deleted { get; set; }

        public Nullable<System.DateTime> CDate { get; set; } 
    }
}
