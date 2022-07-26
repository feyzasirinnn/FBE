using FBE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Views.Shared.Components.UsefulLinks
{
    public class UsefulLinks :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FBEContext db = new FBEContext();

            var usefullinks = db.UsefulLink.ToList().Where(x => x.Deleted == false && x.Enable == true).OrderByDescending(x=>x.Id);
            return View(usefullinks);
        }
    }
}
