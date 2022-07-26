using FBE.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels.Page
{
    public class PageEdit
    {
        [Required]
        [Display(Name = "Sayfa Başlığı")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Sayfa Detayı")]
        public string Description { get; set; }
        [Display(Name = "Page Title")]
        public string TitleEng { get; set; }
        [Display(Name = "Page Description")]
        public string DescriptionEng { get; set; }
        public List<FilePage> Files { get; set; }
        public List<ImagePage> Images { get; set; }
    }
}
