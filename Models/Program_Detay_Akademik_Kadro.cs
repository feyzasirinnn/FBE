using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Program_Detay_Akademik_Kadro
    {
        public int id { get; set; }
        public Programs Program { get; set; }
        public Akademik_Kadro Akademik_Kadro { get; set; }
        //0 ise değil 1 ise evet
        public Boolean Yurutme_Kurulu { get; set; }
        //0 ise değil 1 ise evet
        public Boolean Yeterlilik_Kurulu { get; set; }
    }
}
