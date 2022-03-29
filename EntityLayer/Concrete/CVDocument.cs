using EntityLayer.Concrete.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class CVDocument : MainProperties
    {
        public string fileURL { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}
