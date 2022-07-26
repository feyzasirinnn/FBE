using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBE.ViewModels
{
    public class ResetPasswordView
    {
        [Display(Name = "E-mail Adresiniz")]
        [Required(ErrorMessage = "E-mail alanı gereklidir.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
