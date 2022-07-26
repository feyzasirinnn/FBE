using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels.Kosul
{
    public class KosulEdit
    {
        [Required]
        public int Basvuru_Kos_Tr_Id { get; set; }
        public string Ogretim_Yili_Tr { get; set; }
        public string Donem_Tr { get; set; }
        [Required]
        public int ProgramProg_Id_Tr { get; set; }
        [Required]
        public int Kontenjan_Tr { get; set; }
        [Required]
        public int Yatay_Gec_Kontenjan_Tr { get; set; }
        [Required]
        public int Min_Dil_Puan_Tr { get; set; }
        [Required]
        public int Min_Ales_Tr { get; set; }
        [Required]
        public int Lisans_Ort_Tr { get; set; }
        [Required]
        public int Yuksek_Lisans_Ort_Tr { get; set; }
        [Required]
        public int GRE_Yeni_Tr { get; set; }
        [Required]
        public int GRE_Eski_Tr { get; set; }
        public string Dil_Sart_Tr { get; set; }
        public string Kabul_Edilen_Program_Tr { get; set; }

        //Yabanci

        [Required]
        public int Basvuru_Kos_Yab_Id { get; set; }
        public string Ogretim_Yili_En { get; set; }
        public string Donem_En { get; set; }
        [Required]
        public int ProgramProg_Id_En { get; set; }
        [Required]
        public int Kontenjan_En { get; set; }
        [Required]
        public int Yatay_Gec_Kontenjan_En { get; set; }
        [Required]
        public int Min_Dil_Puan_En { get; set; }
        [Required]
        public int Min_Ales_En { get; set; }
        [Required]
        public int Lisans_Ort_En { get; set; }
        [Required]
        public int Yuksek_Lisans_Ort_En { get; set; }
        [Required]
        public int GRE_Yeni_En { get; set; }
        [Required]
        public int GRE_Eski_En { get; set; }
        public string Dil_Sart_En { get; set; }
        public string Kabul_Edilen_Program_En { get; set; }

    }
}
