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
    public class UserController : Controller
    {
        IActionResult Details(int userId)
        {
            //Þarf að útfæra
            return View();
        }
        IActionResult Update(UserViewModel userToUpdate)
        {
            //Þarf að útfæra
            return View();
        }
    }
}