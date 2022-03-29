using EntityLayer.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Category : MainProperties
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
        }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
