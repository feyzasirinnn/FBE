using FBE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FBE.ViewComponents
{
    public class Properties : ViewComponent
    {
        FBEContext db = new FBEContext();
        public IViewComponentResult Invoke()
        {
            var pr = db.Property.ToList().Where(x=> x.Deleted==false && x.Enable==true);
            ViewBag.culture = CultureInfo.CurrentCulture.Name;
            return View(pr);
        }

    }
}
