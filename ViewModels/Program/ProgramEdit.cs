using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels.Program
{
    public class ProgramEdit
    {
        public int Prog_Id { get; set; }
        public string Prog_Ad { get; set; }
        public string Prog_Ad_En { get; set; }
        public string Prog_Ad_Ar { get; set; }
        public int ProgramDuzeyID { get; set; }
        [Display(Name = "Program Düzeyi")]
        public string ProgramDuzey { get; set; }
        public int EABD_ID { get; set; }
        [Display(Name ="Ana Bilim Dalı")]
        public string EABD { get; set; }
        public List<int> Akademik_Kadro { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
