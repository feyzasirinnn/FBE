using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class IdariCreate
    {
        
        public string ad { get; set; }
        
        public string soyad { get; set; }
        public int Unvan { get; set; }
        public int sicil_no { get; set; }
        public string phone { get; set; }

        public string photo { get; set; }
        public int Gorev { get; set; }
        

    }
}
