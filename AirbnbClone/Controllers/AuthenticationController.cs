﻿using Microsoft.AspNetCore.Mvc;

namespace AirbnbClone.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
