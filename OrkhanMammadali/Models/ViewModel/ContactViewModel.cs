using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrkhanMammadali.Models.ViewModel
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string Adress { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Map { get; set; }
    }
}
