﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrkhanMammadali.Controllers
{
    public class CvDocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
