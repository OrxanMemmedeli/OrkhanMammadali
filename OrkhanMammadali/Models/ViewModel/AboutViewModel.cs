using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrkhanMammadali.Models.ViewModel
{
    public class AboutViewModel
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string Pozition { get; set; }
        public string Info { get; set; }
        public string Experience { get; set; }
        public int AppCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
