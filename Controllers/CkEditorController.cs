using FBE.Models;
using FBE.ViewModels.CkEditor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Controllers
{
    public class CkEditorController : Controller
    {
        private readonly FBEContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CkEditorController(FBEContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var pageImages = _db.PageImages.ToList();
            var announceImages = _db.AnnounceImages.ToList();
            var sliderImages = _db.SliderImages.ToList();
            var model = pageImages.Select(x => new CkModel { Title = x.ImageTitle, Url = x.ImageUrl }).ToList();
            model.AddRange(announceImages.Select(x=>new CkModel { Title = x.ImageTitle,Url=x.ImageUrl}).ToList());
            model.AddRange(sliderImages.Select(x=>new CkModel {Title=x.ImageTitle,Url = x.ImageUrl }).ToList());
            return View(model);
        }
        public IActionResult Images(string index)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0) return null;
            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            var path = Path.Combine(
                _hostingEnvironment.WebRootPath, "storage/img",fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }
            var url = $"{"/storage/img/"}{fileName}";
            return Json(new {url, uploaded = true});
        }
    }
}
