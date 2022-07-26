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
    public class AnnouncementList :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FBEContext db = new FBEContext();

            var an = db.Announce.ToList().Where(x => x.Deleted == false && x.Enable == true ).OrderByDescending(x=>x.StartDate);
            ViewBag.culture = CultureInfo.CurrentCulture.Name;
            return View(an);
        }
    }
}
