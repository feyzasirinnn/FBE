using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Prog_Kadro
    {
        [Key]
        public int PK_Id { get; set; }

        public int Prog_Id { get; set; }
        public ICollection<Programs> Programs { get; set; }

        public int Sicil_No { get; set; }
        public ICollection<Akademik_Kadro> Akademik_Kadro { get; set; }


    }
}
