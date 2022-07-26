using FBE.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels.Kadro
{
    public class KadroEdit
    {
        [Required]
        public int Sicilno { get; set; } //Hocaların kendi sicil numaralarını girmesi için
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string Kullanici_Adi { get; set; }
        [Required]
        public int Gorev { get; set; }
        public int EABDId { get; set; }
        public Boolean EABDBaskan { get; set; }
        [Required]
        public int Unvan { get; set; }
        [Display(Name = "Programlar")]
        public List<Programs> Programs{ get; set; }
        public List<IFormFile> Files { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
