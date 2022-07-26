using FBE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Views.Shared.Components.NavMenu
{
    public class NavMenu: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FBEContext db = new FBEContext();
            var menus = db.Menu.Where(x =>x.MenuStatus == true && x.MenuIsDeleted == false && x.MenuChild == null).OrderBy(x => x.MenuOrder).ToList();
            var childs = db.Menu.Where(x => x.MenuStatus == true && x.MenuIsDeleted == false && x.MenuChild.HasValue).OrderBy(x=>x.MenuOrder).ToList();
            var childs2 = childs.Where(x => childs.Any(y => y.MenuId == x.MenuChild)).ToList();
            ViewBag.childs2 = childs2;
            ViewBag.childs = childs;
            ViewBag.culture = CultureInfo.CurrentCulture.Name;
            return View(menus);
        }
    }
}
