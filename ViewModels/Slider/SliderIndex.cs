using FBE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class SliderIndex
    {
        public string Search { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
