using Microsoft.AspNetCore.Mvc;
using FBE.Models;
using System.Collections.Generic;
using System.Linq;

namespace FBE.ViewComponents
{
    public class Slider : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            FBEContext db = new FBEContext();
            var slider = db.Slider.ToList().Where(x => x.Deleted == false && x.Enable == true);
            return View(slider);
        }
    }
}
