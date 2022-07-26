using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class MenuEdit
    {
        [Required]
        public int MenuId { get; set; }
        [Required]
        public string MenuTitle { get; set; }
        public string MenuTitleEn { get; set; }
        public string MenuURL1 { get; set; }
        public int MenuURL2 { get; set; }
        [Required]
        public string MenuTarget { get; set; }
        [Required]
        public Boolean MenuStatus { get; set; }
        [Required]
        public int? MenuChild { get; set; }
        public int SelectValue { get; set; }
    }
}
