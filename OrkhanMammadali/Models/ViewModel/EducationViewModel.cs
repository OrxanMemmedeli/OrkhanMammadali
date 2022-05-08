using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrkhanMammadali.Models.ViewModel
{
    public class EducationViewModel
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string Company { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Spesiality { get; set; }
        public string IconName { get; set; }
        public string Degree { get; set; }
        public int Order { get; set; } 
    }
}
