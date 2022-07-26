using FBE.Models;
using FBE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class PropertyController : Controller
    {
        private readonly FBEContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PropertyController(FBEContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        public IActionResult Index(string Search = null)
        {
            var model = new PropertyIndex();
            var query = _db.Property.AsQueryable();
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(t =>
                t.Title.Contains(Search));
            }
            model.Properties = query.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new PropertyCreate();

            ViewBag.images = _db.SliderImages.ToList();
            ViewBag.icons = _db.Icons.ToList();
            ViewBag.statics = _db.Pages.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PropertyCreate model)
        {
            if (ModelState.IsValid)
            {
                var modelUrl = "https://localhost:44340/";

                
                if (model.SelectValue == 0)
                {
                    modelUrl += model.PropURL1;
                }
                else
                {
                    var url = _db.Pages.Where(x => x.Id == model.PropURL2).Select(x => x.Id).FirstOrDefault().ToString();
                    modelUrl = modelUrl + "page/index/" + url;
                }

                var property = new Property()
                {
                    Title = model.Title,
                    TitleEn = model.TitleEn,
                    Link = model.Link,
                    PhotoUrl = modelUrl,
                    Deleted = model.Deleted,
                    Enable = model.Enable,
                    Target = model.Target,
                };

                _db.Property.Add(property);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {
            var query = from p in _db.Property
                        where p.Id == id
                        select new PropertyEdit()
                        {
                            Id = p.Id,
                            Title = p.Title,
                            TitleEn = p.TitleEn,
                            PhotoUrl = p.PhotoUrl,
                            Link = p.Link,
                            Deleted = p.Deleted,
                            Enable = p.Enable,
                        };
            var model = query.FirstOrDefault();
            ViewBag.icons = _db.Icons.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(PropertyEdit model)
        {
            if (ModelState.IsValid)
            {
                Property property = _db.Property.FirstOrDefault(t => t.Id == model.Id);
                property.Title = model.Title;
                property.TitleEn = model.TitleEn;
                property.PhotoUrl = model.PhotoUrl;
                property.Link = model.Link;
                property.Deleted = model.Deleted;
                property.Enable = model.Enable;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}