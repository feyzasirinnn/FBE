using FBE.Models;
using FBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Controllers
{
    public class ProgramController : BaseController
    {
        public ProgramController(FBEContext _db) : base(_db)
        {

        }

        public IActionResult Index()
        {
            var model = new ProgramView
            {
                EABD = db.EABD.OrderBy(o => o.EABD_Ad_Tr).ToList(),
                Programs = db.Programs.OrderBy(o => o.Prog_Id).ToList(),

            };
            ViewBag.programs = model.Programs.Select(x => new {
                id = x.Prog_Id,
                tr = x.Prog_Ad + " " + x.Program_Duzey.Prog_Duzey,
                en = x.Prog_Ad_En + " " + x.Program_Duzey.Prog_Duzey_En
            });
            ViewBag.duzeys = db.Program_Duzey.ToList();
            ViewBag.culture = CultureInfo.CurrentCulture.Name;
            return View(model);
        }

        [HttpGet]
        public JsonResult ProgramGoster(int p , string lang)
        {
            var programlar = (from x in db.Programs
                              join y in db.EABD on x.EABD.EABD_Id equals y.EABD_Id
                              where x.EABD.EABD_Id == p
                              select new
                              {
                                  Text = lang.Equals("tr") ? x.Prog_Ad + " - " + x.Program_Duzey.Prog_Duzey : x.Prog_Ad_En + " - " + x.Program_Duzey.Prog_Duzey_En,
                                  Value = x.Prog_Id.ToString()
                              }).ToList();
            return Json(programlar);
        }

        [HttpGet]
        public JsonResult TumProgramlar()
        {
            var programlar = (from x in db.Programs
                              select new
                              {
                                  Text = x.Prog_Ad + " - " + x.Program_Duzey.Prog_Duzey,
                                  Value = x.Prog_Id.ToString()
                              }).ToList();
            return Json(programlar);
        }
        [HttpGet]
        public JsonResult ProgramDetay(int value)
        {
            var dersprogramı = (CultureInfo.CurrentCulture.Name == "tr" ? "Ders Programı" : "Timetable");
            var dersler = (CultureInfo.CurrentCulture.Name == "tr" ? "Dersler" : "Courses");
            var basvurutr = db.Basvuru_Kos_Tr.Include(x => x.Program)
                .Where(x => x.Program.Prog_Id == value).FirstOrDefault();
            var basvuruyab = db.Basvuru_Kos_Yab.Include(x => x.Program)
                .Where(x => x.Program.Prog_Id == value).FirstOrDefault();
            var derslerlink = db.Dersler.Include(x => x.Program)
                .Where(x => x.Program.EbsId == value).FirstOrDefault();
            var detay = db.Programs.Include(x => x.Program_Detay)
                .Include(x=>x.Programs_Akademik_Kadro).ThenInclude(x=>x.Akademik_Kadro)
                .Where(x => x.Prog_Id == value)
                .Select(x=> new {
                    ProgramAdı = x.Prog_Ad,
                    ProgramingAdı = x.Prog_Ad_En,
                    //Dikkat !!
                    ProgramEABDBaskan = x.Programs_Akademik_Kadro.Where(y=>y.Akademik_Kadro.EABDBaskan == true)
                        .Select(y=> new { 
                            AdSoyad = y.Akademik_Kadro.Ad +" "+ y.Akademik_Kadro.Soyad 
                        }).FirstOrDefault().AdSoyad,
                    //----
                    ProgramDuzey = x.Program_Duzey.Prog_Duzey,
                    ProgramDetay = x.Program_Detay.Select(y => y.Program_Detay_),
                    ProgramEABD = x.EABD.EABD_Ad_Tr,
                    ProgramKadro = x.Programs_Akademik_Kadro.Select(y=> new { 
                        name = y.Akademik_Kadro.Ad +" "+ y.Akademik_Kadro.Soyad ,
                        yeterlilik = y.Yeterlilik_Kurulu,
                        yurutme = y.Yurutme_Kurulu,
                        koordinator = y.Koordinator
                    }).ToList(),
                    EbsId = x.EbsId,
                    Basvuru_Kosul_Tr = basvurutr,
                    Basvuru_Kos_Yab = basvuruyab,
                    dersprogramıadı = dersprogramı,
                    dersler = dersler
                }).FirstOrDefault();
            return Json(detay);
        }




       
        }
    }

