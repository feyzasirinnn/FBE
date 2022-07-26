using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class FileKadro
    {
        [Key]
        public int FileId { get; set; }
        public string FileTitle { get; set; }
        public string FileUrl { get; set; }
        
        public Akademik_Kadro FilesKadro{ get; set; }
    }
}
