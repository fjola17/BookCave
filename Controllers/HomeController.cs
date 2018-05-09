using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Repositories;
using BookCave.Models.InputModels;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private BookRepo _bookServices;
        public HomeController()
        {
            _bookServices = new BookRepo();
        }
        public IActionResult FrontPage()
        {
            var books = _bookServices.GetBookIndex();
            return View(books);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(FeedbackInputModel feedback)
        {
            _bookServices.SendFeedback(feedback);
            return RedirectToAction("FrontPage");
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult ShippingInfo()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
