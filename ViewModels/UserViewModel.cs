using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class UserViewModel
    { 
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }
         

        [Required(ErrorMessage = "E-mail adresi zorunludur.")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage ="E-mail adresiniz doğru formatta değil.")]
        public string Email { get; set; }

        [Display(Name ="Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}
