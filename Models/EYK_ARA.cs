using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class EYK_ARA
    {
        public int id { get; set; }
        public Akademik_Kadro Akademik_Kadro { get; set; }
        public EABD EABD { get; set; }
        public Boolean Enstitu_Kurulu { get; set; }
        public Boolean Enstitu_Yonetim_Kurulu { get; set; }
        public Ens_Gorevler Ens_Gorevler { get; set; }
        public EYKUyeler EYKUyeler { get; set; }
        public Unvan Unvan { get; set; }
        public Boolean isActive { get; set; }
    }
}
