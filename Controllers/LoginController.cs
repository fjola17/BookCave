using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
//using BookCave.Services

namespace BookCave.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login(int userId)
        {
            return View();
        }
    }
}