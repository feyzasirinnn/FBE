using FBE.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels.Kadro
{
    public class KadroCreate
    {
        [Required]
        public int Sicil_No { get; set; } //Akademik_kadro table id si için 
        public int Sicilno { get; set; } //Hocaların kendi sicil numaralarını girmesi için
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string Kullanici_Adi { get; set; }
        public int Gorev { get; set; }
        public string Description { get; set; }
        public int EABDId { get; set; }
        public int ImagesId { get; set; }
        public int YonetimUyeId { get; set; }
        public int EnstituUyeId { get; set; }
        public Boolean Uye { get; set; }
        public Boolean EABDBaskan { get; set; }
        public Boolean Yonetim { get; set; }
        public Boolean Enstitu { get; set; }
        [Required]
        public int Unvan { get; set; }
        public string Image { get; set; }
        public Boolean isYKurul { get; set; }
        public Boolean isKurul { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
