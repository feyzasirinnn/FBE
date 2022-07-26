using FBE.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class AnnounceIndex
    {
        public string Search { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<Announce> Announcements { get; set; }
    }
}
