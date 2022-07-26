using FBE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FBE.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Email model)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add( "feyzasirinnn@gmail.com");
            mailim.From = new MailAddress("feyzasirinnn@gmail.com");
            mailim.Subject = "Bize Ulaşın Sayfanızdan Mesajınız Var" + model.Baslik;
            mailim.Body = "Sayın Yetkili" + model.AdSoyad + "kişisinden gelen mesajın içeriği aşağıdaki gibidir.<br>" + model.Icerik;
            mailim.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("feyzasirinnn@gmail.com","EF301019");
            smtp.Port = 587;
            smtp.Host = "smtp@gmail.com";
            smtp.EnableSsl = true;

            try { 

            smtp.Send(mailim);
                TempData["Message"] = "Mesajınız iletilmiştir.";

            }
            catch(Exception ex)
            {
                TempData["Message"] = "Mesaj gönderilemedi. Hata nedeni:" + ex.Message;
            }
            return View();
        }
    }
}
