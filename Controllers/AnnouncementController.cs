using FBE.Models;
using FBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FBE.Controllers
{
    public class AnnouncementController : BaseController
    {
        public AnnouncementController(FBEContext _db) : base(_db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            ViewBag.culture = CultureInfo.CurrentCulture.Name;
            return View(await PaginatedList<Announce>.CreateAsync(db.Announce.Where(x=> x.Deleted == false && 
            x.Enable == true).OrderByDescending(x => x.StartDate), pageNumber, 10));
        }
        public IActionResult Details(int id)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            ViewBag.culture = culture;
            var query = from c in db.Announce
                        where c.Id == id
                        select new AnnounceDetails()
                        {
                            Title = c.Title,
                            TitleEn = c.TitleEng,
                            Description = c.Description,
                            DescriptionEn = c.DescriptionEng,
                            Date = c.StartDate
                        };
            var model = query.FirstOrDefault();
            return View(model);
        }

        public IActionResult ImportantAnnounce()
        {
          
                
            ViewBag.culture = CultureInfo.CurrentCulture.Name;
            var an = db.Announce.ToList()
                                .Where(x => x.Deleted == false && x.Enable == true && x.IsImportant == true )
                                .OrderByDescending(x => x.StartDate);
            return View(an);
        }


    }
}
