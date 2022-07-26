using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.Models
{
    public class FBEContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public FBEContext()
        {

        }
        public FBEContext(DbContextOptions<FBEContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Akademik_Kadro> Akademik_Kadro { get; set; }
        public virtual DbSet<Basvuru_Kos_Tr> Basvuru_Kos_Tr { get; set; }
        public virtual DbSet<Basvuru_Kos_Yab> Basvuru_Kos_Yab { get; set; }
        public virtual DbSet<Dersler> Dersler { get; set; }
        public virtual DbSet<EABD> EABD { get; set; }
        public virtual DbSet<Ens_Kurulu> Ens_Kurulu { get; set; }
        public virtual DbSet<EYK_ARA> EYK_ARA { get; set; }
        public virtual DbSet<Programs> Programs { get; set; }
        public virtual DbSet<Program_Detay> Program_Detay { get; set; }
        public virtual DbSet<Program_Duzey> Program_Duzey { get; set; }
        public virtual DbSet<Unvan> Unvan { get; set; }
        public virtual DbSet<EYKUyeler> EYKUyeler { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Idari_Personel> Idari_Personel { get; set; }
        public virtual DbSet<Ens_Gorevler> Ens_Gorevler { get; set; }
        public virtual DbSet<Icons> Icons { get; set; }
        public virtual DbSet<FileKadro> FileKadro { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Announce> Announce { get; set; }
        public virtual DbSet<Slider2> Slider2 { get; set; }
        public virtual DbSet<UsefulLink> UsefulLink { get; set; }
        public virtual DbSet<Programs_Akademik_Kadro> ProgramAkademik_Kadro { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<FilePage> PageFiles { get; set; }
        public virtual DbSet<ImagePage> PageImages { get; set; }
        public virtual DbSet<ImageProgram> ImagePrograms { get; set; }
        public virtual DbSet<FileProgram> FilePrograms { get; set; }
        public virtual DbSet<KadroImage> KadroImages { get; set; }
        public virtual DbSet<FileAnnouncement> AnnounceFiles { get; set; }
        public virtual DbSet<ImageAnnouncement> AnnounceImages { get; set; }
        public virtual DbSet<ImageSlider> SliderImages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {//"Data source=LAPTOP-JR55JGDS;Initial Catalog=FBE;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

                optionsBuilder.UseSqlServer("Data source=LAPTOP-JR55JGDS;Initial Catalog=FBE;Integrated Security=True");
            }
        }
        
      
    }
}
