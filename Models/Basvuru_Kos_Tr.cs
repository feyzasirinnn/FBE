using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Basvuru_Kos_Tr
    {
        [Key]
        public int Basvuru_Kos_Tr_Id { get; set; }
        public string Ogretim_Yili { get; set; }
        public string Donem { get; set; }
        public Programs  Program { get; set; }
        public int Kontenjan { get; set; }
        public int Yatay_Gec_Kontenjan { get; set; }
        public int Min_Dil_Puan { get; set; }
        public int Min_Ales { get; set; }
        public int Lisans_Ort { get; set; }
        public int Yuksek_Lisans_Ort { get; set; }
        public int GRE_Yeni { get; set; }
        public int GRE_Eski { get; set; }
        public string Dil_Sart { get; set; }
        public string Kabul_Edilen_Program { get; set; }

        public bool isDeleted { get; set; }


    }
}
