using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrkhanMammadali.Models.ViewModel
{
    public class SosialViewModel
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string NetworkName { get; set; }
        public string IconName { get; set; }
        public string Url { get; set; }
    }
}
