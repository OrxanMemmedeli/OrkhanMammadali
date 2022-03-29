using EntityLayer.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Contact : MainProperties
    {
        public string Adress { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Map { get; set; }
    }
}
