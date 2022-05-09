using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrkhanMammadali.Models.ViewModel
{
    public class SkillViewModel
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public int Persent { get; set; }
        public string fileURL { get; set; }

        public int Width { get; set; }
        public int Order { get; set; }
    }
}
