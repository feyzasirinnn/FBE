using FBE.Models;
using FBE.ViewModels.Kosul;
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
    public class ConditionsController : Controller
    {
        FBEContext _Db;

        public ConditionsController(FBEContext db)
        {
            _Db = db;
        }

        public IActionResult Index()
        {
            var tr = _Db.Basvuru_Kos_Tr.Include(x=>x.Program).Where(x=>x.isDeleted == false).ToList();
            var en = _Db.Basvuru_Kos_Yab.Include(x => x.Program).Where(x => x.isDeleted == false).ToList();
            KosullarIndex model = new KosullarIndex() { Tr = tr, Yab = en };
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.model = _Db.Programs.ToList();
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(KosulCreate dto)
        {
            if (ModelState.IsValid)
            {
                Basvuru_Kos_Tr basvuru_Kos_Tr = new Basvuru_Kos_Tr()
                {
                    Dil_Sart = dto.Dil_Sart_Tr,
                    Donem = dto.Donem_Tr,
                    GRE_Eski = dto.GRE_Eski_Tr,
                    GRE_Yeni = dto.GRE_Yeni_Tr,
                    Kabul_Edilen_Program = dto.Kabul_Edilen_Program_Tr,
                    Program = _Db.Programs.Find(dto.Program_Tr),
                    Kontenjan = dto.Kontenjan_Tr,
                    Lisans_Ort = dto.Lisans_Ort_Tr,
                    Min_Ales = dto.Min_Ales_Tr,
                    Min_Dil_Puan = dto.Min_Dil_Puan_Tr,
                    Ogretim_Yili = dto.Ogretim_Yili_Tr,
                    Yatay_Gec_Kontenjan = dto.Yuksek_Lisans_Ort_Tr,
                    Yuksek_Lisans_Ort = dto.Yuksek_Lisans_Ort_Tr
                };

                Basvuru_Kos_Yab basvuru_Kos_Yab = new Basvuru_Kos_Yab()
                {
                    Dil_Sart = dto.Dil_Sart_En,
                    Donem = dto.Donem_En,
                    GRE_Eski = dto.GRE_Eski_En,
                    GRE_Yeni = dto.GRE_Yeni_Tr,
                    Kabul_Edilen_Program = dto.Kabul_Edilen_Program_En,
                    Program = _Db.Programs.Find(dto.Program_En),
                    Kontenjan = dto.Kontenjan_En,
                    Lisans_Ort = dto.Lisans_Ort_En,
                    Min_Ales = dto.Min_Ales_En,
                    Min_Dil_Puan = dto.Min_Dil_Puan_En,
                    Ogretim_Yili = dto.Ogretim_Yili_En,
                    Yatay_Gec_Kontenjan = dto.Yuksek_Lisans_Ort_En,
                    Yuksek_Lisans_Ort = dto.Yuksek_Lisans_Ort_En
                };

                _Db.Basvuru_Kos_Tr.Add(basvuru_Kos_Tr);
                _Db.Basvuru_Kos_Yab.Add(basvuru_Kos_Yab);
                _Db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }


        
        public IActionResult Edit(int id)
        {
            var kosultr = _Db.Basvuru_Kos_Tr.Include(x=>x.Program).Where(x => x.Basvuru_Kos_Tr_Id == id).FirstOrDefault();
            var kosulen = _Db.Basvuru_Kos_Yab.Include(x => x.Program).Where(x => x.Basvuru_Kos_Yab_Id == id).FirstOrDefault();

            KosulEdit dto = new KosulEdit()
            {

                Basvuru_Kos_Tr_Id = kosultr.Basvuru_Kos_Tr_Id,
                Dil_Sart_Tr = kosultr.Dil_Sart,
                GRE_Eski_Tr = kosultr.GRE_Eski,
                GRE_Yeni_Tr = kosultr.GRE_Yeni,
                Donem_Tr = kosultr.Donem,
                Kontenjan_Tr = kosultr.Kontenjan,
                Min_Ales_Tr = kosultr.Min_Ales,
                Min_Dil_Puan_Tr = kosultr.Min_Dil_Puan,
                Ogretim_Yili_Tr = kosultr.Ogretim_Yili,
                Kabul_Edilen_Program_Tr = kosultr.Kabul_Edilen_Program,
                Lisans_Ort_Tr = kosultr.Lisans_Ort,
                Yuksek_Lisans_Ort_Tr = kosultr.Yuksek_Lisans_Ort,
                Yatay_Gec_Kontenjan_Tr = kosultr.Yatay_Gec_Kontenjan,
                ProgramProg_Id_Tr = kosultr.Program.Prog_Id,


                //Yabanci

                Basvuru_Kos_Yab_Id = kosulen.Basvuru_Kos_Yab_Id,
                Dil_Sart_En = kosulen.Dil_Sart,
                GRE_Eski_En = kosulen.GRE_Eski,
                GRE_Yeni_En = kosulen.GRE_Yeni,
                Donem_En = kosulen.Donem,
                Kontenjan_En = kosulen.Kontenjan,
                Min_Ales_En = kosulen.Min_Ales,
                Min_Dil_Puan_En = kosulen.Min_Dil_Puan,
                Ogretim_Yili_En = kosulen.Ogretim_Yili,
                Kabul_Edilen_Program_En = kosulen.Kabul_Edilen_Program,
                Lisans_Ort_En = kosulen.Lisans_Ort,
                Yuksek_Lisans_Ort_En = kosulen.Yuksek_Lisans_Ort,
                Yatay_Gec_Kontenjan_En = kosulen.Yatay_Gec_Kontenjan,
                ProgramProg_Id_En = kosulen.Program.Prog_Id

            };

            ViewBag.model = _Db.Programs.ToList();

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(KosulEdit dto)
        {
            var kosultr = _Db.Basvuru_Kos_Tr.Include(x => x.Program).Where(x => x.Basvuru_Kos_Tr_Id == dto.Basvuru_Kos_Tr_Id).FirstOrDefault();
            var kosulen = _Db.Basvuru_Kos_Yab.Include(x => x.Program).Where(x => x.Basvuru_Kos_Yab_Id == dto.Basvuru_Kos_Yab_Id).FirstOrDefault();

            kosultr.Basvuru_Kos_Tr_Id = dto.Basvuru_Kos_Tr_Id;
            kosultr.Dil_Sart = dto.Dil_Sart_Tr;
            kosultr.Donem = dto.Donem_Tr;
            kosultr.GRE_Eski = dto.GRE_Eski_Tr;
            kosultr.GRE_Yeni = dto.GRE_Yeni_Tr;
            kosultr.Kabul_Edilen_Program = dto.Kabul_Edilen_Program_Tr;
            kosultr.Program = _Db.Programs.Find(dto.ProgramProg_Id_Tr);
            kosultr.Kontenjan = dto.Kontenjan_Tr;
            kosultr.Lisans_Ort = dto.Lisans_Ort_Tr;
            kosultr.Min_Ales = dto.Min_Ales_Tr;
            kosultr.Min_Dil_Puan = dto.Min_Dil_Puan_Tr;
            kosultr.Ogretim_Yili = dto.Ogretim_Yili_Tr;
            kosultr.Yatay_Gec_Kontenjan = dto.Yuksek_Lisans_Ort_Tr;
            kosultr.Yuksek_Lisans_Ort = dto.Yuksek_Lisans_Ort_Tr;

            //Yabanci

            kosulen.Basvuru_Kos_Yab_Id = dto.Basvuru_Kos_Yab_Id;
            kosulen.Dil_Sart = dto.Dil_Sart_En;
            kosulen.Donem = dto.Donem_En;
            kosulen.GRE_Eski = dto.GRE_Eski_En;
            kosulen.GRE_Yeni = dto.GRE_Yeni_En;
            kosulen.Kabul_Edilen_Program = dto.Kabul_Edilen_Program_En;
            kosulen.Program = _Db.Programs.Find(dto.ProgramProg_Id_En);
            kosulen.Kontenjan = dto.Kontenjan_En;
            kosulen.Lisans_Ort = dto.Lisans_Ort_En;
            kosulen.Min_Ales = dto.Min_Ales_En;
            kosulen.Min_Dil_Puan = dto.Min_Dil_Puan_En;
            kosulen.Ogretim_Yili = dto.Ogretim_Yili_En;
            kosulen.Yatay_Gec_Kontenjan = dto.Yuksek_Lisans_Ort_En;
            kosulen.Yuksek_Lisans_Ort = dto.Yuksek_Lisans_Ort_En;



            _Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var valuetr = _Db.Basvuru_Kos_Tr.FirstOrDefault(x => x.Basvuru_Kos_Tr_Id == id );
            var valueyab = _Db.Basvuru_Kos_Yab.FirstOrDefault(x => x.Basvuru_Kos_Yab_Id == id);
            valuetr.isDeleted = true;
            valueyab.isDeleted = true;
            _Db.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public JsonResult BasvuruKon(int value)
        {
            var basvuru = _Db.Basvuru_Kos_Tr.Include(x => x.Program)
                
                .Where(x => x.Program.Prog_Id == value)
                .Select(x => new {
                    Ogretim_Yili = x.Ogretim_Yili,
                    Donem=x.Donem,
                    Kontenjan = x.Kontenjan,
                    Yatay_Gec_Kon = x.Yatay_Gec_Kontenjan,
                    Gerekli_Lisans_Ort = x.Lisans_Ort,
                    Ales = x.Min_Ales,
                    GRE_Eski=x.GRE_Eski,
                    GRE_Yeni = x.GRE_Yeni,
                    Dil_Sart=x.Dil_Sart,
                    Kabul_Edilen_Prog=x.Kabul_Edilen_Program

                }).FirstOrDefault();
            return Json(basvuru);
        }
    }
}
