using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPILayer.Models.ViewModels
{
    public class EditUserViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "İstifadəçi adi boş ola bilməz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email boş ola bilməz.")]
        [EmailAddress(ErrorMessage = "Email düzgün daxil edilməyib.")]
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
