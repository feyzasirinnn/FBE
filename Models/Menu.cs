using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuTitle { get; set; }
        public string MenuTitleEn { get; set; }
        public string MenuURL { get; set; }
        public string MenuTarget { get; set; }
        public Boolean MenuStatus { get; set; }
        public Boolean MenuIsDeleted { get; set; }
        public int? MenuChild { get; set; }
        public int? MenuOrder { get; set; }
    }
}
