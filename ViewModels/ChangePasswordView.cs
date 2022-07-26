using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class ChangePasswordView
    {
        [Display(Name ="Eski şifreniz")]
        [Required(ErrorMessage ="Eski şifreniz gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage ="Şifre en az 4 karakterli olmalıdır.")]
        public string OldPassword { get; set; } 

        [Display(Name = "Yeni şifreniz")]
        [Required(ErrorMessage = "Yeni şifreniz gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifre en az 4 karakterli olmalıdır.")]
       
        public string NewPassword { get; set; }

        [Display(Name = "Yeni şifre onay")]
        [Required(ErrorMessage = "Yeni şifre onayı gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifre en az 4 karakterli olmalıdır.")]
        [Compare("NewPassword",ErrorMessage ="Şifreler birbirinden farklıdır.")]
        public string ConfirmPassword { get; set; }
    }
}
