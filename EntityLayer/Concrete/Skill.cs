using EntityLayer.Concrete.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Skill : MainKnowledge
    {
        public string fileURL { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }
    }
}
