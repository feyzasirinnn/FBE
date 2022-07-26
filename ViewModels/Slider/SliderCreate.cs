using FBE.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class SliderCreate
    {
        
        [DisplayName("Fotoğraf Linki")]
        public string PhotoUrl1 { get; set; }
        [DisplayName("Fotoğraf")]
        public int PhotoUrl2 { get; set; }
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
        public int SelectValue { get; set; }
        public int ImagesId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
