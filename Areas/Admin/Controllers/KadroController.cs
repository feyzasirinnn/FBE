using FBE.Models;
using FBE.ViewModels.Kadro;
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
    public class KadroController : Controller
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

        public KadroController(FBEContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = _db.Akademik_Kadro.Include(x=>x.Unvan).Include(x=>x.EABDId).Include(x => x.Programs_Akademik_Kadro).Include(x => x.EGorevId).Where(x => x.IsDeleted == false).ToList();
            
            ViewBag.images = _db.KadroImages.ToList();
            ViewBag.files = _db.FileKadro.ToList();
            return View(model);
        }

        [HttpPost]
        public JsonResult UnvanCreate(string unvan)
        {
            Unvan unvan1 = new Unvan() { Unvan_Name = unvan };
            _db.Unvan.Add(unvan1);
            _db.SaveChanges();
            return Json(new { data =  unvan1});
        }

        [HttpPost]
        public IActionResult GorevCreate(string gorev )
        {
            Ens_Gorevler gorev1 = new Ens_Gorevler() { EGorev_Name = gorev };
            _db.Ens_Gorevler.Add(gorev1);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }
        public IActionResult Create()
        {
            ViewBag.EABD = _db.EABD.ToList();
            ViewBag.Unvan = _db.Unvan.ToList();
            ViewBag.ensgorevler = _db.Ens_Gorevler.ToList();

            return View();
        }
        
        [HttpPost]
        public IActionResult Create(KadroCreate kadroCreate)
        {
            if (ModelState.IsValid)
            {

                var File = kadroCreate.Files;
                var Images = kadroCreate.Images;
                var modelUrl = "https://https://localhost:44340//";
                var url = _db.Akademik_Kadro.Where(x => x.Sicil_No == kadroCreate.ImagesId).Select(x => x.Sicil_No).FirstOrDefault().ToString();
                modelUrl = modelUrl + "kadro/index/" + url;

                Akademik_Kadro kadro = new Akademik_Kadro()
                {
                    Sicilno = kadroCreate.Sicilno,
                    Ad = kadroCreate.Ad,
                    Soyad = kadroCreate.Soyad,
                    Kullanici_Adi = kadroCreate.Kullanici_Adi,
                    EABDId = _db.EABD.Find(kadroCreate.EABDId),
                    EABDBaskan = kadroCreate.EABDBaskan,
                    EGorevId = _db.Ens_Gorevler.Find(kadroCreate.Gorev),
                    Unvan = _db.Unvan.Find(kadroCreate.Unvan)
                };
                _db.Akademik_Kadro.Add(kadro);
                if (File != null)
                {
                    foreach (var item in File)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\kadros\\files");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        Models.FileKadro file = new Models.FileKadro()
                        {
                            FileTitle = uniqueFileName,
                            FileUrl =  filePath,
                            FilesKadro = kadro
                        };
                        _db.FileKadro.Add(file);
                    }
                }

                if (Images != null)
               {
                    foreach (var item in Images)
                    {
                        var uniqueFileName = GetUniqueFileName(item.FileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\kadros\\images");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        item.CopyTo(new FileStream(filePath, FileMode.Create));
                        KadroImage kadroimg = new KadroImage()
                        {
                            
                            ImageTitle = uniqueFileName,
                            ImageUrl = "\\storage\\kadros\\images\\" + uniqueFileName,
                            AkademikImage = kadro
                       };
                       _db.KadroImages.Add(kadroimg);
                        
                   }
                }
              
                if (kadroCreate.EABDBaskan)
                {
                    var kdr = _db.Akademik_Kadro.Include(x => x.EABDId).ToList();
                    foreach (var item in kdr)
                    {
                        if (_db.EABD.Find(kadroCreate.EABDId) == item.EABDId)
                        {
                            if (item.EABDBaskan == true)
                            {
                                kadroCreate.EABDBaskan = false;
                            }
                        }
                    }
                }
                

                if (kadroCreate.Yonetim)
            {
                var yntm = _db.EYKUyeler.Include(x=>x.Akademik_Kadro).ToList();
                foreach (var item in yntm)
                {
                    
                        if (item.Akademik_Kadro.Yonetim == true)
                        {
                            kadroCreate.Yonetim = false;
                        }
                    
                }
            }

            if (kadroCreate.Enstitu)
            {
                var ens = _db.Akademik_Kadro.Include(x => x.Ens_KuruluId).ToList();
                foreach (var item in ens)
                {
                    if (_db.Ens_Kurulu.Find(kadroCreate.EnstituUyeId) == item.Ens_KuruluId)
                    {
                        if (item.Enstitu == true)
                        {
                            kadroCreate.Enstitu = false;
                        }
                    }
                }
            }

            }
            
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Akademik_Kadro kadro = _db.Akademik_Kadro.Include(x=>x.EABDId).Include(x=>x.Unvan).Include(x => x.EGorevId).Include(x => x.Files).Include(x => x.Image).Where(x=>x.Sicil_No == id).FirstOrDefault();
            KadroEdit dto = new KadroEdit()
            {
                Ad = kadro.Ad,
                Soyad = kadro.Soyad,
                Sicilno = kadro.Sicilno,
                Kullanici_Adi = kadro.Kullanici_Adi,
                EABDId = kadro.EABDId.EABD_Id,
                EABDBaskan = kadro.EABDBaskan,
                Gorev = kadro.EGorevId.EGorev_Id,
                Unvan = kadro.Unvan.Unvan_Id,
                Programs = _db.ProgramAkademik_Kadro.Where(x => x.Akademik_Kadro == kadro).Select(x => x.Program).ToList()
        };


            var files = _db.Akademik_Kadro.ToList().Where(x => x.IsDeleted == false );
            ViewBag.EABD = _db.EABD.ToList();
            ViewBag.Unvan = _db.Unvan.ToList();
            ViewBag.ensgorevler = _db.Ens_Gorevler.ToList();
            return View(dto);
        }
        [HttpPost]
        public IActionResult FileUpload(List<IFormFile> files, int id)
        {
            if (files != null)
            {
                foreach (var item in files)
                {
                    var uniqueFileName = GetUniqueFileName(item.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\kadros\\files");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    item.CopyTo(new FileStream(filePath, FileMode.Create));
                    Models.FileKadro file = new Models.FileKadro()
                    {
                        FileTitle = uniqueFileName,
                        FileUrl = filePath,
                        FilesKadro = _db.Akademik_Kadro.Find(id)
                    };
                    _db.FileKadro.Add(file);
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
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\kadros\\images");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    item.CopyTo(new FileStream(filePath, FileMode.Create));
                    KadroImage img = new KadroImage()
                    {
                        ImageTitle = item.FileName,
                        ImageUrl = "\\storage\\kadros\\images\\" + uniqueFileName,
                        AkademikImage = _db.Akademik_Kadro.Find(id)
                    };
                    _db.KadroImages.Add(img);
                }
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = id });
            }
            return RedirectToAction("Edit", new { id = id });
        }

        public IActionResult FileDelete(int id, int returnid)
        {
            var file = _db.FileKadro.Find(id);
            var filepath = file.FileUrl;
            _db.Remove(file);
            _db.SaveChanges();
            return RedirectToAction("Edit", new { id = returnid });
        }

        public IActionResult ImageDelete(int id, int returnid)
        {
            var img = _db.KadroImages.Find(id);
            var filepath = img.ImageUrl;
            _db.Remove(img);
            _db.SaveChanges();
            return RedirectToAction("Edit", new { id = returnid });
        }
        [HttpPost]
        public IActionResult Edit(int id,KadroEdit dto)
        {
            if (dto.EABDBaskan)
            {
                var kdr = _db.Akademik_Kadro.Include(x => x.EABDId).ToList();
                foreach (var item in kdr)
                {
                    if (_db.EABD.Find(dto.EABDId) == item.EABDId)
                    {
                        if (item.EABDBaskan == true)
                        {
                            dto.EABDBaskan = false;
                        }
                    }
                }
            }

            var files = dto.Files;
            var images = dto.Images;
            Akademik_Kadro kadro = _db.Akademik_Kadro.Find(id);
            kadro.Ad = dto.Ad;
            kadro.Soyad = dto.Soyad;
            kadro.Sicilno = dto.Sicilno;
            kadro.Kullanici_Adi = dto.Kullanici_Adi;
            kadro.EABDId = _db.EABD.Find(dto.EABDId);
            kadro.EABDBaskan = dto.EABDBaskan;
            kadro.EGorevId = _db.Ens_Gorevler.Find(dto.Gorev);
            kadro.Unvan = _db.Unvan.Find(dto.Unvan);            

            if (files != null)
            {

                var oldFiles = _db.FileKadro.Where(file => file.FilesKadro == kadro).ToList();//Bu dosyalar silinecek

                oldFiles.ForEach(file =>
                {
                    _db.FileKadro.Remove(file);
                    var filepath = file.FileUrl;
                    //System.IO.File.Delete(filepath);
                });

                foreach (var item in files)
                {
                    var uniqueFileName = GetUniqueFileName(item.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\kadros\\files");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    item.CopyTo(new FileStream(filePath, FileMode.Create));
                    Models.FileKadro file = new Models.FileKadro()
                    {
                        FileTitle = uniqueFileName,
                        FileUrl = filePath,
                        FilesKadro = kadro
                    };
                    _db.FileKadro.Add(file);
                }
            }
            if (images != null)
            {

                var oldImages = _db.KadroImages.Where(img => img.AkademikImage == kadro).ToList();//Bu Resimler silinecek

                oldImages.ForEach(img =>
                {
                    _db.KadroImages.Remove(img);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\kadros\\images");
                    var filePath = Path.Combine(uploads, img.ImageUrl);
                    //System.IO.File.Delete(filePath); //Dosya silinemiyor
                });

                foreach (var item in images)
                {
                    var uniqueFileName = GetUniqueFileName(item.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "storage\\kadros\\images");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    item.CopyTo(new FileStream(filePath, FileMode.Create));
                    KadroImage kadroimg = new KadroImage()
                    {

                        ImageTitle = uniqueFileName,
                        ImageUrl = "\\storage\\kadros\\images\\" + uniqueFileName,
                        AkademikImage = kadro
                    };
                    _db.KadroImages.Add(kadroimg);

                }
            }

           
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
         public IActionResult Delete(int id)
        {
            var value = _db.Akademik_Kadro.FirstOrDefault(x => x.Sicil_No == id);
            value.IsDeleted = true;
            var images = _db.KadroImages.Where(image => image.AkademikImage.Sicil_No == id).ToList();
            images.ForEach(img =>
            {
                _db.KadroImages.Remove(img);
            });
            var files = _db.FileKadro.Where(file => file.FilesKadro.Sicil_No == id).ToList();
            files.ForEach(file=>
            {
                _db.FileKadro.Remove(file);
            });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Yetki(int id,int kadroid)
        {
            var program = _db.ProgramAkademik_Kadro
                .Where(x => x.Program == _db.Programs.Find(id) && x.Akademik_Kadro == _db.Akademik_Kadro.Find(kadroid) && x.isActive == true)
                .Select(x => new
                {
                    Yurutme = x.Yurutme_Kurulu,
                    Yeterlilik = x.Yeterlilik_Kurulu,
                    Koordinator = x.Koordinator
                })
                .FirstOrDefault();
            return Json(new {data = program });
        }


        [HttpGet]
        public JsonResult Uye(int id, int uyeid)
        {
            var uye = _db.EYK_ARA
                .Where(x => x.EYKUyeler == _db.EYKUyeler.Find(id) && x.Akademik_Kadro == _db.Akademik_Kadro.Find(uyeid) && x.isActive == true)
                .Select(x => new
                {
                    Yonetim = x.Enstitu_Yonetim_Kurulu,
                    Enstitu = x.Enstitu_Kurulu,
                })
                .FirstOrDefault();
            return Json(new { data = uye });
        }

        [HttpPost]
        public IActionResult Yetki(int id,int kadroid,bool yurutme,bool yeterlilik,bool koordinator)
        {
            var program = _db.Programs.Where(x => x.Prog_Id == id).FirstOrDefault();
            var progkadro = _db.ProgramAkademik_Kadro.Where(x => x.Akademik_Kadro == _db.Akademik_Kadro.Find(kadroid) && x.Program == program && x.isActive == true).FirstOrDefault();
            if (progkadro!=null)
            {
                progkadro.Yurutme_Kurulu = yurutme;
                progkadro.Yeterlilik_Kurulu = yeterlilik;
                progkadro.Koordinator = koordinator;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

       
        public JsonResult getAllKadros()
        {
            var kadros = _db.Akademik_Kadro.Include(x => x.EABDId).Include(x => x.EGorevId)

                .Select(x => new
                {
                    sicilNo = x.Sicil_No,
                    kadroName = x.Ad + " "+ x.Soyad,
                    kullanici_adi=x.Kullanici_Adi,
                    gorevId = x.EGorevId.EGorev_Name,
                    EABDId =x.EABDId.EABD_Ad_Tr,
                    EABDbaskan=x.EABDBaskan,
                    unvanId=x.Unvan.Unvan_Name

                })
                .ToList();
            return Json(new { data = kadros });
        }
    }
}
