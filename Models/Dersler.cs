using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Dersler
    {
        [Key]
        public int Ders_Id { get; set; }
        [Required]
        public string Ders_Ad { get; set; }
        [Required]
        public string Ders_Ad_En { get; set; }
        //1 ise yüksek lisans 0 ise doktora
        public bool Seviye { get; set; }
        //1 ise zorunlu 0 ise seçmeli
        public bool Tur { get; set; }
        //1 ise türkçe 0 ise ingilizce
        public bool Dil { get; set; }
        public Programs  Program { get; set; }


    }
}
