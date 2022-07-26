using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class EABD
    {
        [Key]
        public int EABD_Id { get; set; }
        [Required]
        public string EABD_Ad_Tr { get; set; }
        [Required]
        public string EABD_Ad_En { get; set; }
        //public int EABDBaskan { get; set; }
        //[ForeignKey(nameof(EABDBaskan))]
        //public Akademik_Kadro Akademik_Kadro { get; set; }
    }
}
