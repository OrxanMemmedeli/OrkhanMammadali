using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPILayer.Models.ViewModels
{
    public class EditPasswordViewModel
    {
        [Required(ErrorMessage = "Yeni şifrə boş ola bilməz.")]
        public string NewPassword { get; set; }
    }
}
