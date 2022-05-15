using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class AppUser :IdentityUser<Guid>
    {
        public bool Status { get; set; }
    }
}
