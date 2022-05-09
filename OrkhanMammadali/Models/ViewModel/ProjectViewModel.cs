using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrkhanMammadali.Models.ViewModel
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileURL { get; set; }
        public string URLadress { get; set; }
        public int? Order { get; set; }
        public Guid CategoryID { get; set; }

        public CategoryViewModel CategoryViewModel { get; set; }
    }
}
