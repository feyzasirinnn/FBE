using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class ImageSlider
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageTitle { get; set; }
        public string ImageUniqueTitle { get; set; }
        public string ImageUrl { get; set; }
        public  Slider sliders { get; set; }
    }
}
