using FBE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Controllers
{
    public class PageController : Controller
    {
        private readonly FBEContext _db;

        public PageController(FBEContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            var model = _db.Pages.Include(x=>x.Files).Where(x=>x.Id == id).FirstOrDefault();
            ViewBag.culture = CultureInfo.CurrentCulture.Name;
            return View(model);
        }

        public IActionResult Download(string url,string name)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(url);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = name;
            return File(content,contentType,fileName);
        }
    }
}
