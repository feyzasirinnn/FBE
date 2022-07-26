using FBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class EabdController : Controller
    {
        FBEContext _db;

        public EabdController(FBEContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string eabd,string eabdEn)
        {
            EABD bolum = new EABD()
            {
                EABD_Ad_Tr=eabd,
                EABD_Ad_En = eabdEn
            };
            _db.EABD.Add(bolum);
            _db.SaveChanges();
            return RedirectToAction("Create","Program");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var eabd = _db.EABD.Find(id);
            return Json(new { data = eabd });
        }

        [HttpPost]
        public IActionResult Edit(int id,string eabd,string eabdEn)
        {
            EABD bolum =_db.EABD.Find(id);
            bolum.EABD_Ad_Tr = eabd;
            bolum.EABD_Ad_En = eabdEn;
            _db.SaveChanges();
            return RedirectToAction("Create","Program");
        }

        public void Delete(int id)
        {
            _db.EABD.Remove(_db.EABD.Find(id));
            _db.SaveChanges();
        }
    }
}
