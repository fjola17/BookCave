using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.EntityModels; //Breyta þessu
//using BookCave.Services

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
//        private BookServices _bookServices { get; set; }
/*
        public BookController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        */
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            //Þarf að útfæra
            return View();
        }
        public IActionResult Review(Review newReview)
        {
            //Þarf að útfæra
            return View();
        }
        public IActionResult Search(string searchString)
        {

            //þarf að útfæra inn í book repo
            return View();
        }
    }
}