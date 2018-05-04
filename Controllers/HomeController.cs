using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Repositories;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private BookRepo _bookServices;
        public HomeController(BookRepo bookServices)
        {
            _bookServices = bookServices;
        }
        public IActionResult FrontPage()
        {
            var books = _bookServices.GetBookIndex();
            return View(books);
        }     

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
