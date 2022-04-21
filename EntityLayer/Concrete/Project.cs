using EntityLayer.Concrete.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Project : MainProperties
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileURL { get; set; }
        public string URLadress { get; set; }

        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
