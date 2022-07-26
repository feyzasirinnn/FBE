using FBE.Controllers;
using FBE.Models;
using FBE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class MenuController : BaseController
    {
        public MenuController(FBEContext _db) : base(_db)
        {

        }

        public IActionResult Index()
        {
            var values = db.Menu.ToList().Where(x => x.MenuIsDeleted == false).OrderBy(x=>x.MenuOrder);
            var childs = db.Menu.ToList().Where(x => x.MenuIsDeleted == false && x.MenuChild.HasValue).OrderBy(x => x.MenuOrder);
            ViewBag.childs = childs;
            return View(values);
        }

        public IActionResult Create()
        {
            var model = new MenuCreate();
            var menus = db.Menu.ToList().Where(x => x.MenuIsDeleted == false);
            ViewBag.menus = menus;
            ViewBag.statics = db.Pages.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(MenuCreate menu)
        {
            if (ModelState.IsValid)
            {
                var modelUrl = "";
                if (menu.SelectValue == 0)
                {
                    modelUrl += menu.MenuURL1;
                }
                else
                {
                    var url = db.Pages.Where(x => x.Id == menu.MenuURL2).Select(x=>x.Id).FirstOrDefault().ToString();
                    modelUrl = modelUrl + "page/index/"+url;
                }
                var m = new Menu()
                {
                    MenuTitle = menu.MenuTitle,
                    MenuTitleEn = menu.MenuTitleEn,
                    MenuURL=modelUrl,
                    MenuTarget=menu.MenuTarget,
                    MenuChild = menu.MenuChild
                };
                if (m.MenuChild == 0)
                {
                    m.MenuChild = null;
                }
                db.Menu.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var query = from p in db.Menu
                        where p.MenuId == id
                        select new MenuEdit()
                        {
                            MenuId = p.MenuId,
                            MenuTitle = p.MenuTitle,
                            MenuTitleEn = p.MenuTitleEn,
                            MenuURL1 = p.MenuURL,
                            MenuTarget = p.MenuTarget,
                            MenuStatus = p.MenuStatus,
                            MenuChild = p.MenuChild
                        };
            var model = query.FirstOrDefault();
            var menus = db.Menu.ToList().Where(x => x.MenuIsDeleted == false && x.MenuChild == null);
            ViewBag.menus = menus;
            ViewBag.statics = db.Pages.ToList();
            ViewBag.id = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MenuEdit model,int id)
        {
            if (ModelState.IsValid)
            {
                var modelUrl = "";
                if (model.SelectValue == 0)
                {
                    modelUrl = model.MenuURL1;
                }
                else
                {
                    var url = db.Pages.Where(x => x.Id == model.MenuURL2).Select(x => x.Id).FirstOrDefault().ToString();
                    modelUrl += "page/index/" + url;
                }
                Menu menu = db.Menu.FirstOrDefault(x => x.MenuId == id);
                menu.MenuTitle = model.MenuTitle;
                menu.MenuTitleEn = model.MenuTitleEn;
                menu.MenuURL = modelUrl;
                menu.MenuTarget = model.MenuTarget;
                menu.MenuStatus = model.MenuStatus;
                if (model.MenuChild == 0)
                {
                    menu.MenuChild = null;
                }
                else
                {
                    menu.MenuChild = model.MenuChild;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var value = db.Menu.FirstOrDefault(x=>x.MenuId==id);
            value.MenuIsDeleted = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
