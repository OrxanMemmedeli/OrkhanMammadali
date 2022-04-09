using EntityLayer.Concrete.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Profil : MainProperties
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoURL { get; set; }

        public string Pozition { get; set; }
    }
}
