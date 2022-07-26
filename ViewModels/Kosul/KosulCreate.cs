using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels.Kosul
{
    public class KosulCreate
    {
        public string Ogretim_Yili_Tr { get; set; }
        public string Donem_Tr { get; set; }
        public int Program_Tr { get; set; }
        public int Kontenjan_Tr { get; set; }
        public int Yatay_Gec_Kontenjan_Tr { get; set; }
        public int Min_Dil_Puan_Tr { get; set; }
        public int Min_Ales_Tr { get; set; }
        public int Lisans_Ort_Tr { get; set; }
        public int Yuksek_Lisans_Ort_Tr { get; set; }
        public int GRE_Yeni_Tr { get; set; }
        public int GRE_Eski_Tr { get; set; }
        public string Dil_Sart_Tr { get; set; }
        public string Kabul_Edilen_Program_Tr { get; set; }

        //Yabanci
        public string Ogretim_Yili_En { get; set; }
        public string Donem_En { get; set; }
        public int Program_En { get; set; }
        public int Kontenjan_En { get; set; }
        public int Yatay_Gec_Kontenjan_En { get; set; }
        public int Min_Dil_Puan_En { get; set; }
        public int Min_Ales_En { get; set; }
        public int Lisans_Ort_En{ get; set; }
        public int Yuksek_Lisans_Ort_En { get; set; }
        public int GRE_Yeni_En { get; set; }
        public int GRE_Eski_En { get; set; }
        public string Dil_Sart_En { get; set; }
        public string Kabul_Edilen_Program_En { get; set; }
    }
}
