using FBE.Models;
using FBE.ViewModels;
using FBE.ViewModels.Idari;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class IdariController : Controller
    {
        FBEContext _db;

        public IdariController(FBEContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = _db.Idari_Personel.Include(x => x.Unvan).Include(x => x.Ens_Gorevler).Include(x => x.Akademik_Kadro).ToList();
            return View(model);
        }

        

        public IActionResult Create()
        {
            ViewBag.akademikkadro = _db.Akademik_Kadro.ToList();
            ViewBag.ensgorevler = _db.Ens_Gorevler.ToList();
            ViewBag.Unvan = _db.Unvan.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdariCreate idariCreate)
        {

            Idari_Personel idari = new Idari_Personel()
            {
                ad = idariCreate.ad,
                soyad = idariCreate.soyad,
                EGorev_Id = idariCreate.Gorev,
                Ens_Gorevler = _db.Ens_Gorevler.Find(idariCreate.Gorev),
                Sicil_No= idariCreate.sicil_no,
                Akademik_Kadro = _db.Akademik_Kadro.Find(idariCreate.sicil_no),
                phone = idariCreate.phone,
                photo = idariCreate.phone,
                Unvan_Id = idariCreate.Unvan,
                Unvan = _db.Unvan.Find(idariCreate.Unvan)
            };
            _db.Idari_Personel.Add(idari);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Idari_Personel idari = _db.Idari_Personel.Include(x => x.Unvan).Include(x => x.Ens_Gorevler).Include(x => x.Akademik_Kadro).FirstOrDefault();
            IdariEdit dto = new IdariEdit()
            {
                ad = idari.ad,
                soyad = idari.soyad,
                Gorev = idari.Ens_Gorevler.EGorev_Id,
                sicil_no = idari.Akademik_Kadro.Sicil_No,
                phone = idari.phone,
                photo = idari.photo,
                Unvan = idari.Unvan.Unvan_Id,
               // Programs = _db.ProgramAkademik_Kadro.Where(x => x.Akademik_Kadro == kadro).Select(x => x.Program).ToList()
            };
            ViewBag.ensgorevler = _db.Ens_Gorevler.ToList();
            ViewBag.Unvan = _db.Unvan.ToList();
            ViewBag.akademikkadro = _db.Akademik_Kadro.ToList();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(int id, IdariEdit dto)
        {
            Idari_Personel idari = _db.Idari_Personel.Find(id);

            idari.ad = dto.ad;
            idari.soyad = dto.soyad;
            idari.Ens_Gorevler = _db.Ens_Gorevler.Find(dto.Gorev);
            idari.Akademik_Kadro = _db.Akademik_Kadro.Find(dto.sicil_no);
            idari.phone = dto.phone;
            idari.photo = dto.photo;
            idari.Unvan = _db.Unvan.Find(dto.Unvan);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _db.Idari_Personel.Remove(_db.Idari_Personel.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult getAllIdaries()
        {
            var idaries = _db.Idari_Personel.Include(x=>x.Unvan).Include(x => x.Ens_Gorevler)

                .Select(x => new
                {
                    idariId= x.idari_Id,
                    idariName = x.ad + " " + x.soyad,
                    kullanici_adi = x.Akademik_Kadro.Kullanici_Adi,
                    EGorevName = x.Ens_Gorevler.EGorev_Name,
                    Unvan = x.Unvan.Unvan_Name,
                    photo = x.photo,
                    phone = x.phone,
                })
                .ToList();
            return Json(new { data = idaries });
        }
    }
}
