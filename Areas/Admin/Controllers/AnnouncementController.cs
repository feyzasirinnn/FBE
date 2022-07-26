    using FBE.Controllers;
using FBE.Models;
using FBE.ViewModels; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class AnnouncementController : Controller
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

        public AnnouncementController(FBEContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            var model = new AnnounceIndex();
            var query = _db.Announce.Where(x => x.Deleted == false).OrderByDescending(x => x.StartDate);
            model.Announcements = query.ToList();
            ViewBag.images = _db.AnnounceImages.ToList();
            ViewBag.files = _db.AnnounceFiles.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new AnnouncementCreate();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AnnouncementCreate model)
        {
            if (ModelState.IsValid)
            {
                var File = model.Files;
                var Images = model.Images;
                var modelUrl = "https://https://localhost:44340//";
                var url = _db.Announce.Where(x => x.Id == model.ImagesId).Select(x => x.Id).FirstOrDefault().ToString();
                modelUrl = modelUrl + "Announcement/index/" + url;

                var announce = new Announce()
                {
                    Title = model.Title,
                    Description = model.Description,
                    TitleEng = model.TitleEng,
                    DescriptionEng = model.DescriptionEng,
                    Enable = model.Enable,
                    Deleted = model.Deleted,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Popup = model.Popup,
                    IsImportant = model.IsImportant
                };
                _db.Announce.Add(announce);

                if (File != null)
                {
                    foreach (var item in File)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\announcements\\files");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        Models.FileAnnouncement announcementfile = new Models.FileAnnouncement()
                        {
                            FileTitle = uniqueFileName,
                            FileUrl = filePath,
                            AnnounceFile = announce
                        };
                        _db.AnnounceFiles.Add(announcementfile);
                    }
                }

                if (Images != null)
                {
                    foreach (var item in Images)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\announcements\\images");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        ImageAnnouncement announcementimg = new ImageAnnouncement()
                        {

                            ImageTitle = uniqueFileName,
                            ImageUrl = "\\storage\\announcements\\images\\" + uniqueFileName,
                            AnnounceImage = announce
                        };
                        _db.AnnounceImages.Add(announcementimg);

                    }
                }


                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Announce announce = _db.Announce.Include(x => x.Files).Include(x => x.Image).FirstOrDefault();
            var query = from p in _db.Announce
                        where p.Id == id
                        select new AnnouncementEdit()
                        {
                            Id = p.Id,
                            Title = p.Title,
                            Description = p.Description,
                            TitleEng = p.TitleEng,
                            DescriptionEng = p.DescriptionEng,
                            Enable = p.Enable,
                            Deleted = p.Deleted,
                            Date = p.StartDate,
                            Popup = p.Popup,
                            IsImportant = p.IsImportant

                        };
            var model = query.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public IActionResult FileUpload(List<IFormFile> files, int id)
        {
            if (files != null)
            {
                foreach (var item in files)
                {
                    var uniqueFileName = GetUniqueFileName(item.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\announcements\\files");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    item.CopyTo(new FileStream(filePath, FileMode.Create));
                    Models.FileAnnouncement file = new Models.FileAnnouncement()
                    {
                        FileTitle = uniqueFileName,
                        FileUrl = filePath,
                        AnnounceFile = _db.Announce.Find(id)
                    };
                    _db.AnnounceFiles.Add(file);
                }
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = id });
            }
            return RedirectToAction("Edit", new { id = id });
        }

        [HttpPost]
        public IActionResult ImageUpload(List<IFormFile> images, int id)
        {
            if (images != null)
            {
                foreach (var item in images)
                {
                    var uniqueFileName = GetUniqueFileName(item.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\announcements\\images");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    item.CopyTo(new FileStream(filePath, FileMode.Create));
                    ImageAnnouncement img = new ImageAnnouncement()
                    {
                        ImageTitle = item.FileName,
                        ImageUrl = "\\storage\\announcements\\images\\" + uniqueFileName,
                        AnnounceImage = _db.Announce.Find(id)
                    };
                    _db.AnnounceImages.Add(img);
                }
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = id });
            }
            return RedirectToAction("Edit", new { id = id });
        }

        public IActionResult FileDelete(int id, int returnid)
        {
            var file = _db.AnnounceFiles.Find(id);
            var filepath = file.FileUrl;
            _db.Remove(file);
            _db.SaveChanges();
            return RedirectToAction("Edit", new { id = returnid });
        }

        public IActionResult ImageDelete(int id, int returnid)
        {
            var img = _db.AnnounceImages.Find(id);
            var filepath = img.ImageUrl;
            _db.Remove(img);
            _db.SaveChanges();
            return RedirectToAction("Edit", new { id = returnid });
        }


        [HttpPost]
        public IActionResult Edit(AnnouncementEdit model)
        {
            if (ModelState.IsValid)
            {
                var files = model.Files;
                var images = model.Images;
                Announce announce = _db.Announce.FirstOrDefault(t => t.Id == model.Id);
                announce.Title = model.Title;
                announce.Description = model.Description;
                announce.TitleEng = model.TitleEng;
                announce.DescriptionEng = model.DescriptionEng;
                announce.StartDate = model.Date;
                announce.Deleted = model.Deleted;
                announce.Enable = model.Enable;
                announce.IsImportant = model.IsImportant;
                announce.Popup = model.Popup;

                if (files != null)
                {

                    var oldFiles = _db.AnnounceFiles.Where(file => file.AnnounceFile == announce).ToList();//Bu dosyalar silinecek

                    oldFiles.ForEach(file =>
                    {
                        _db.AnnounceFiles.Remove(file);
                        var filepath = file.FileUrl;
                    });

                    foreach (var item in files)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\announcements\\files");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        Models.FileAnnouncement file = new Models.FileAnnouncement()
                        {
                            FileTitle = uniqueFileName,
                            FileUrl = filePath,
                            AnnounceFile = announce
                        };
                        _db.AnnounceFiles.Add(file);
                    }
                }
                if (images != null)
                {

                    var oldImages = _db.AnnounceImages.Where(img => img.AnnounceImage == announce).ToList();//Bu Resimler silinecek

                    oldImages.ForEach(img =>
                    {
                        _db.AnnounceImages.Remove(img);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\announcements\\images");
                        var filePath = Path.Combine(uploads, img.ImageUrl);
                        //System.IO.File.Delete(filePath); //Dosya silinemiyor
                    });

                    foreach (var item in images)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\announcements\\images");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        ImageAnnouncement announceimg = new ImageAnnouncement()
                        {

                            ImageTitle = uniqueFileName,
                            ImageUrl = "\\storage\\announcements\\images\\" + uniqueFileName,
                            AnnounceImage = announce
                        };
                        _db.AnnounceImages.Add(announceimg);

                    }
                }


                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(model);

        }

        public IActionResult Delete(int id)
        {
            var value = _db.Announce.FirstOrDefault(x => x.Id == id);
            value.Deleted  = true;
            var images = _db.AnnounceImages.Where(image => image.AnnounceImage.Id == id).ToList();
            images.ForEach(img =>
            {
                _db.AnnounceImages.Remove(img);
            });
            var files = _db.AnnounceFiles.Where(file => file.AnnounceFile.Id == id).ToList();
            files.ForEach(file =>
            {
                _db.AnnounceFiles.Remove(file);
            });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}