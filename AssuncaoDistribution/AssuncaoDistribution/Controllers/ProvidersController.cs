﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Controllers
{
    public class ProvidersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}