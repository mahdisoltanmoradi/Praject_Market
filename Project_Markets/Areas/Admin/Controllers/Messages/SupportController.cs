﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Markets.Areas.Admin.Controllers.Messages
{
    [Area("Admin")]
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}