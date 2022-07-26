using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Page
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEng { get; set; }
        public string Description { get; set; }
        public string DescriptionEng { get; set; }
        public ICollection<FilePage> Files { get; set; }
        public ICollection<ImagePage> Images { get; set; }
    }
}
