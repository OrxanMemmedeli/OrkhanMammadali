using EntityLayer.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Category : MainProperties
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int? Order { get; set; }
        //public ICollection<Project> Projects { get; set; }
    }
}
