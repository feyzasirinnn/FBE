using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class AnnounceDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public DateTime Date { get; set; }
        public Nullable<System.DateTime> CDate { get; set; }
        public IEnumerable<AnnounceDetails> Announce { get; set; }
    }
}
