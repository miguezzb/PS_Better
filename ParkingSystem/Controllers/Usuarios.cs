﻿using Microsoft.AspNetCore.Mvc;

namespace ParkingSystem.Controllers
{
    public class Usuarios : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
