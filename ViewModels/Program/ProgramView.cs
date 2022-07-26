using FBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class ProgramView
    {
        public int? EABD_Id { get; set; }
        public int? Prog_Id { get; set; }
 
        public ProgramView()
        {
            this.EABD = new List<EABD>();
            this.Programs = new List<Programs>();
        }

        public IEnumerable<EABD> EABD { get; set; }
        public IEnumerable<Programs> Programs { get; set; }

    }
}
