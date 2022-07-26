using FBE.Models;
using FBE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class ULinksController : Controller
    {
        FBEContext db = new FBEContext();
        public IActionResult Index(string Search = null)
        {
            var model = new UsefulLinkIndex();
            var query = db.UsefulLink.AsQueryable();
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(t =>
                t.Title.Contains(Search));
            }
            model.UsefulLinks = query.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new UsefulLinkCreate(); 
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(UsefulLinkCreate model)
        {
            if (ModelState.IsValid)
            {
                var ulink = new UsefulLink()
                {
                    Title = model.Title,
                    Link = model.Link,
                    Enable = model.Enable,
                    Deleted = model.Deleted, 
                };
                db.UsefulLink.Add(ulink);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var query = from ulink in db.Property
                        where ulink.Id == id
                        select new UsefulLinkEdit()
                        {
                            Id = ulink.Id,
                            Title = ulink.Title,
                            Link = ulink.Link,
                            Deleted = ulink.Deleted,
                            Enable = ulink.Enable, 
                        };
            var model = query.FirstOrDefault(); 
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UsefulLinkEdit model)
        {
            if (ModelState.IsValid)
            {
                UsefulLink ulink = db.UsefulLink.FirstOrDefault(t => t.Id == model.Id);
                ulink.Title = model.Title;
                ulink.Link = model.Link;
                ulink.Deleted = model.Deleted;
                ulink.Enable = model.Enable; 
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(model);
        }
    }
}