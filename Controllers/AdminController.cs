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
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            //Þarf að útfæra betur
            return View();
        }
        public IActionResult CreateBook(BookViewModel newBook)
        {
            //Þarf að útfæra betur
            return View();
        }
        public IActionResult UpdateBook(BookViewModel updatedBook)
        {
            //Þarf að útfæra betur
            return View();
        }
    }
}