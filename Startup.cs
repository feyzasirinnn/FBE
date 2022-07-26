using FBE.CustomValidation;
using FBE.Models;
using FBE.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FBE
{
    public class Startup
    {
        public IWebHostEnvironment HostingEnvironment { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FBEContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FBE")));
            services.AddIdentity<AppUser, AppRole>
                (opts =>
                {
                    opts.User.RequireUniqueEmail = true;
                    opts.User.AllowedUserNameCharacters =
                    "abcçdefgðhýijklmnoöpqrsþtuüvwxyzABCÇDEFGÐHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789_.-";

                    opts.Password.RequiredLength = 4;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = false;
                }).AddPasswordValidator<CustomPasswordValidator>()
                .AddUserValidator<CustomUserValidator>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<FBEContext>();
            services.AddControllersWithViews();
            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var suppertedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("tr"),
                        new CultureInfo("en")
                    };
                options.DefaultRequestCulture = new RequestCulture("tr");
                options.SupportedCultures = suppertedCultures;
                options.SupportedUICultures = suppertedCultures;
            });
            services.AddRazorPages();
            services.AddSession();

            CookieBuilder cookieBuilder = new CookieBuilder();
            cookieBuilder.Name = "FBE";
            cookieBuilder.HttpOnly = false;
            cookieBuilder.SameSite = SameSiteMode.Lax;
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;




            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = new PathString("/Admin/Account/Login");
                opts.Cookie = cookieBuilder;
                opts.SlidingExpiration = true;
            });

            var mvcBuilder = services.AddControllersWithViews();


            mvcBuilder.AddRazorRuntimeCompilation();
            services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            

        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IWebHostEnvironment env
            , RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var role = roleManager.Roles.Where(x => x.Name == "Admin").FirstOrDefault();
            if (role == null)
            {
                roleManager.CreateAsync(new AppRole { Name = "Admin" }).Wait();
            }
        }
    }
}
