using FBE.Models;
using FBE.ViewModels.EYKUyeler;
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
    public class EYKUyelerController : Controller
    {
        FBEContext _Db;

        public EYKUyelerController(FBEContext db)
        {
            _Db = db;
        }
        public IActionResult Index()
        {
            var model = _Db.EYKUyeler.Include(x => x.EABD).ToList();
            ViewBag.EABD = _Db.EABD.ToList();
            ViewBag.Akademik_Kadro = _Db.Akademik_Kadro.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.EABD = _Db.EABD.ToList();
            ViewBag.Kadro = _Db.Akademik_Kadro.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EYKUyelerCreate eykuyeCreate)
        {

            EYKUyeler newUye = new EYKUyeler();
            newUye.EABD = _Db.EABD.Find(eykuyeCreate.EYKUyelerEABD);
            _Db.EYKUyeler.Add(newUye);
            for (int i = 0; i < eykuyeCreate.EYKUyelerKadro.Count; i++)
            {
                EYK_ARA eykak = new EYK_ARA()
                {
                    EYKUyeler = newUye,
                    Akademik_Kadro = _Db.Akademik_Kadro.Find(eykuyeCreate.EYKUyelerKadro[i]),
                    isActive = true
                };
                _Db.EYK_ARA.Add(eykak);
            }
            newUye.isActive = true;
            _Db.SaveChanges();

            return RedirectToAction("index");
        }


        public JsonResult getAllEYKUyelers()
        {
            var eykuye = _Db.EYKUyeler.Include(x => x.EABD).Include(x => x.Akademik_Kadro).Include(x => x.Ens_Gorevler)
                .Select(x => new
                {
                    eykuyeId = x.eyk_uyeler_ID,
                    eykuyeName = x.Akademik_Kadro.Ad + "" + x.Akademik_Kadro.Soyad,
                    eykuyeGorev = x.Ens_Gorevler.EGorev_Name,
                    eykuyeEABDId = x.EABD.EABD_Id,
                    eykuyeEABD = x.EABD.EABD_Ad_Tr,
                })
                .ToList();
            return Json(new { data = eykuye });
        }
    }
}
