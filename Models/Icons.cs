using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Icons
    {
        [Key]
        public int icon_id { get; set; }
        [Required]
        public string iconName { get; set; }
        public string iconURL { get; set; }
    }
}
