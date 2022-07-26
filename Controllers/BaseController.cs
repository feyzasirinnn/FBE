using FBE.Models;
using Microsoft.AspNetCore.Mvc;

namespace FBE.Controllers
{
    public abstract class BaseController : Controller
    {
        public readonly FBEContext db;
        public BaseController(FBEContext _db)
        {
            this.db = _db;
        } 
    }
}