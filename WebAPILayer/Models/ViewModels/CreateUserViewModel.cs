using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPILayer.Models.ViewModels
{
    public class CreateUserViewModel
    {

        [Required(ErrorMessage = "Şifrə boş ola bilməz")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifrələr arası uyğunsuzluq")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Email düzgün yazılmayıb")]
        [Required(ErrorMessage = "Email boş ola bilməz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "İstifadəçi adı boş ola bilməz")]
        public string UserName { get; set; }
    }
}
