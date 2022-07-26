using FBE.Models;
using FBE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class SliderController : Controller
    {
        private readonly FBEContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SliderController(FBEContext db, IWebHostEnvironment hostingEnvironment)
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
            var model = new SliderIndex();
            var query = _db.Slider.AsQueryable();
            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(t =>
                t.Title.Contains(Search));
            }
            model.Sliders = query.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SliderCreate();
            
            ViewBag.statics = _db.Pages.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SliderCreate model)
        {
            if (ModelState.IsValid)
            {


                var Images = model.Images;
               
                var photoUrl = "";

                var slider = new Slider()
                {
                    Title = model.Title,
                    Order = model.Order,
                    CDate = model.CDate,
                    Deleted = model.Deleted,
                    Enable = model.Enable,
                    Link = model.Link,
                    PhotoUrl = photoUrl
                };
                if (Images != null)
                {
                    foreach (var item in Images)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "s");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        ImageSlider sliderimg = new ImageSlider()
                        {

                            ImageTitle = uniqueFileName,
                            ImageUrl = "storage\\sliders\\images\\" + uniqueFileName,
                            sliders = slider
                        };
                        _db.SliderImages.Add(sliderimg);

                    }
                }

                _db.SaveChanges();

                if (model.SelectValue == 0)
                {

                    var url = _db.SliderImages.Where(x => x.sliders == slider).Select(x => x.ImageUrl).FirstOrDefault();
                    photoUrl = photoUrl + url;

                }
                else 
                {

                    var url = _db.SliderImages.Where(x => x.sliders == slider).Select(x => x.ImageUrl).FirstOrDefault();
                    photoUrl = photoUrl + url;

                }
                slider.PhotoUrl = photoUrl;
                _db.Slider.Update(slider);
                _db.SaveChanges();


                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult ImageUploadCreate(IFormFile image)
        {
            if (image != null)
            {
                var uniqueFileName = GetUniqueFileName(image.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\sliders\\images");
                var filePath = Path.Combine(uploads, uniqueFileName);
                image.CopyTo(new FileStream(filePath, FileMode.Create));
                ImageSlider img = new ImageSlider()
                {
                    ImageTitle = image.FileName,
                    ImageUrl = filePath
                };
                _db.SliderImages.Add(img);
                _db.SaveChanges();
                return RedirectToAction("Create");
            }
            return RedirectToAction("Create");
            
        }
        public IActionResult ImageDelete(int id, int returnid)
        {
            var img = _db.SliderImages.Find(id);
            var filepath = img.ImageUrl;
            _db.Remove(img);
            _db.SaveChanges();
            return RedirectToAction("Edit", new { id = returnid });
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var query = from slider in _db.Slider
                        where slider.Id == id
                        select new SliderEdit()
                        {
                            Id = slider.Id,
                            Title = slider.Title,
                            PhotoUrl = slider.PhotoUrl,
                            Link = slider.Link,
                            Order = slider.Order,
                            CDate = slider.CDate,
                            Deleted = slider.Deleted,
                            Enable = slider.Enable,
                        };
            var model = query.FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SliderEdit model)
        {
            if (ModelState.IsValid)
            {
                Slider slider = _db.Slider.FirstOrDefault(t => t.Id == model.Id);
                slider.Title = model.Title;
                slider.PhotoUrl = model.PhotoUrl;
                slider.Link = model.Link;
                slider.Order = model.Order;
                slider.CDate = model.CDate;
                slider.Deleted = model.Deleted;
                slider.Enable = model.Enable;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {

            _db.Slider.Remove(_db.Slider.Find(id));
            var images = _db.SliderImages.Where(image => image.sliders.Id == id).ToList();
            images.ForEach(img =>
            {
                _db.SliderImages.Remove(img);
            });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}