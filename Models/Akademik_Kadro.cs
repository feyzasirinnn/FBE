using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class Akademik_Kadro
    {
        [Key]
        public int Sicil_No { get; set; } //Akademik_kadro table id si için 
        
        [Required]
        public string Ad { get; set; }
        public string Soyad{ get; set; }
        [Required]
        public string Kullanici_Adi { get; set; }
        public int Sicilno { get; set; } //Hocaların kendi sicil numaralarını girmesi için
        
        public EABD EABDId { get; set; }
        public Ens_Kurulu Ens_KuruluId { get; set; }
        public Boolean EABDBaskan { get; set; }
        public Boolean Yonetim { get; set; }
        public Boolean Enstitu { get; set; }
        public Boolean IsDeleted { get; set; }
        public Unvan Unvan { get; set; }
        public Ens_Gorevler EGorevId { get; set; }
        public virtual ICollection<Programs_Akademik_Kadro> Programs_Akademik_Kadro { get; set; } 
        public ICollection<FileKadro> Files { get; set; }
        public ICollection<KadroImage> Image { get; set; }

    }
}
