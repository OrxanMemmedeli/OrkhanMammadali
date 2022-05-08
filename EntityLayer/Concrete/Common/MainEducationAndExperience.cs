using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete.Common
{
    public abstract class MainEducationAndExperience: MainProperties
    {
        public string Company { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Spesiality { get; set; }
        public string IconName { get; set; }
        public int? Order { get; set; } = 1;

    }
}
