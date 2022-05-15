using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPILayer.Models.ViewModels
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Rol boş ola bilməz.")]
        public string Name { get; set; }
    }
}
