using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Programs
    {
        [Key]
        public int Prog_Id { get; set; }
        [Required]
        public string Prog_Ad { get; set; }
        [Required]
        public string Prog_Ad_En { get; set; }
        public string Prog_Ad_Ar { get; set; }
        public int ProgramDuzey { get; set; }
        public EABD  EABD { get; set; }
        public ICollection<Programs_Akademik_Kadro> Programs_Akademik_Kadro { get; set; }
        public ICollection<Program_Detay> Program_Detay { get; set; }
        [ForeignKey(nameof(ProgramDuzey))]
        public Program_Duzey Program_Duzey { get; set; }
        public int? EbsId { get; set; }
        public Boolean isActive { get; set; }
        
        public ICollection<FileProgram> Files { get; set; }
        public ICollection<ImageProgram> Image { get; set; }
    }
}
