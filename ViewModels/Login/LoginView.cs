using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class LoginView
    {
        [Display(Name ="E-mail Adresiniz")]
        [Required(ErrorMessage ="E-mail alanı gereklidir.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage ="Şifreniz en az 4 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}
