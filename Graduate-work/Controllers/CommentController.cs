﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_work.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult AddComment()
        {
            return View();
        }

        public IActionResult DelitComment()
        {
            return View();
        }
    }
}
