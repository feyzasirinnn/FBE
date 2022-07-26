using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class FilePage
    {
        [Key]
        public int FileId { get; set; }
        public string FileTitle { get; set; }
        public string FileUrl { get; set; }
        public int PageId { get; set; }
        [ForeignKey(nameof(PageId))]
        public Page FilesPage { get; set; }
    }
}
