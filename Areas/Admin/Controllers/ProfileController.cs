using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBE.Models;
using FBE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace FBE.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class ProfileController : Controller
    {
        public UserManager<AppUser> userManager { get; }

        public SignInManager<AppUser> signInManager { get; }

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public IActionResult Index()
        {

            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            UserViewModel userView = user.Adapt<UserViewModel>();

            return View(userView);
        }

        [HttpGet]
        public IActionResult UserEdit()
        {
            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            UserViewModel userview = user.Adapt<UserViewModel>();


            return View(userview);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserViewModel userView)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
                user.UserName = userView.UserName;
                user.Email = userView.Email;
                user.PhoneNumber = userView.PhoneNumber;

                IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);

                    await signInManager.SignOutAsync();
                    await signInManager.SignInAsync(user, true);


                    ViewBag.success = "true";
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }


            return View(userView);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordView changePassword)
        {
            if (ModelState.IsValid)
            {
                AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
                if (user != null)
                {
                    bool exist = userManager.CheckPasswordAsync(user, changePassword.OldPassword).Result;
                    if (exist)
                    {
                        IdentityResult result = userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword).Result;
                        if (result.Succeeded)
                        {
                            userManager.UpdateSecurityStampAsync(user);

                            signInManager.SignOutAsync();
                            signInManager.PasswordSignInAsync(user, changePassword.NewPassword, true, false);

                            ViewBag.success = "true";
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Eksik veya yanlış eski şifre");
                    }
                }


            }
            return View(changePassword);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return LocalRedirect("/Admin/Account/Login");
        }

    }
}