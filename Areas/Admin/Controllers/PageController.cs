using FBE.Models;
using FBE.ViewModels.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class PageController : Controller
    {
        private readonly FBEContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public PageController(FBEContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = _db.Pages.ToList();
            return View(model);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PageCreate dto)
        {
            if (ModelState.IsValid)
            {
                var File = dto.Files;
                var Images = dto.Images;
                Page page = new Page()
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    TitleEng = dto.TitleEng,
                    DescriptionEng = dto.DescriptionEng
                };
                _db.Pages.Add(page);
                if (File != null)
                {
                    foreach (var item in File)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage/pages/files");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        Models.FilePage file = new Models.FilePage()
                        {
                            FileTitle = uniqueFileName,
                            FileUrl = filePath,
                            FilesPage = page
                        };
                        _db.PageFiles.Add(file);
                    }
                }
                if (Images != null)
                {
                    foreach (var item in Images)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage/pages/images");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        ImagePage img = new ImagePage()
                        {
                            ImageTitle=item.FileName,
                            ImageUrl = filePath,
                            ImagesPage = page
                        };
                        _db.PageImages.Add(img);
                    }
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Pages.Include(x=>x.Files).Include(x=>x.Images).Where(x=>x.Id == id).FirstOrDefault();
            PageEdit dto = new PageEdit() {
                Title = model.Title,
                Description = model.Description,
                TitleEng = model.TitleEng,
                DescriptionEng = model.DescriptionEng,
                Files = model.Files.ToList(),
                Images = model.Images.ToList()
            };
            ViewBag.id = id;
            return View(dto);
        }

        [HttpPost]
        public IActionResult FileUpload(List<IFormFile> files,int id)
        {
            if (files != null)
            {
                foreach (var item in files)
                {
                    var uniqueFileName = GetUniqueFileName(item.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage/pages/files");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    item.CopyTo(new FileStream(filePath, FileMode.Create));
                    Models.FilePage file = new Models.FilePage()
                    {
                        FileTitle = uniqueFileName,
                        FileUrl = filePath,
                        FilesPage = _db.Pages.Find(id)
                    };
                    _db.PageFiles.Add(file);
                }
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = id });
            }
            return RedirectToAction("Edit", new { id = id });
        }
        
        [HttpPost]
        public IActionResult ImageUpload(List<IFormFile> images,int id)
        {
            if (images != null)
            {
                foreach (var item in images)
                {
                    var uniqueFileName = GetUniqueFileName(item.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage/pages/images");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    item.CopyTo(new FileStream(filePath, FileMode.Create));
                    ImagePage img = new ImagePage()
                    {
                        ImageTitle = item.FileName,
                        ImageUrl = "~/storage/pages/images/"+uniqueFileName,
                        ImagesPage = _db.Pages.Find(id)
                    };
                    _db.PageImages.Add(img);
                }
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = id });
            }
            return RedirectToAction("Edit", new { id = id });
        }

        public IActionResult FileDelete(int id,int returnid)
        {
            var file = _db.PageFiles.Find(id);
            var filepath = file.FileUrl;
            System.IO.File.Delete(filepath);
            _db.Remove(file);
            _db.SaveChanges();
            return RedirectToAction("Edit",new { id = returnid });
        }
        
        public IActionResult ImageDelete(int id,int returnid)
        {
            var img = _db.PageImages.Find(id);
            var filepath = img.ImageUrl;
            System.IO.File.Delete(filepath);
            _db.Remove(img);
            _db.SaveChanges();
            return RedirectToAction("Edit",new { id = returnid });
        }

        [HttpPost]
        public IActionResult Edit(PageEdit dto,int id)
        {
            if (ModelState.IsValid)
            {
                var page = _db.Pages.Find(id);
                page.Title = dto.Title;
                page.Description = dto.Description;
                page.TitleEng = dto.TitleEng;
                page.DescriptionEng = dto.DescriptionEng;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var model = _db.Pages.Find(id);
            _db.Pages.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
