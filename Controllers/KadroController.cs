using FBE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Controllers
{
    public class KadroController : Controller
    {
        FBEContext _db;
        public KadroController(FBEContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.URL = _db.KadroImages.ToList();
            ViewBag.Unvan = _db.Unvan.ToList();
            return View();
        }
    }
}
