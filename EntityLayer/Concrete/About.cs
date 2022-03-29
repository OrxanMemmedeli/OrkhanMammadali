using EntityLayer.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class About : MainProperties
    {
        public string Pozition { get; set; }
        public string Info { get; set; }
        public string Experience { get; set; }
        public int AppCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
