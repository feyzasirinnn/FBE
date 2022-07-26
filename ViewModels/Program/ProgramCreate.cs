using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels.Program
{
    public class ProgramCreate
    {
        public string Prog_Ad { get; set; }
        public string Prog_Ad_En { get; set; }
        public string Prog_Ad_Ar { get; set; }
        public int ProgramDuzey { get; set; }
        public int ProgramEABD { get; set; }
        public int ImagesId { get; set; }
        public List<int> ProgramKadro { get; set; }
        public int EBSId { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
