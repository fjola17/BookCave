using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
//using BookCave.Services

namespace BookCave.Controllers
{
    public class RegisterController : Controller
    {
        private UserRepo _newUser;
        RegisterController()
        {
            _newUser = new UserRepo();
        }
        public IActionResult Create(UserViewModel newUser)
        {
            //Þarf að útfæra betur
            return View();
        }
    }
}