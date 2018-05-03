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
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            //Þarf að útfæra
            return View();
        }
        public IActionResult Details(int ReviewID)
        {
            //þarf að útfæra
            return View();
        }
        public IActionResult Create(ReviewViewModel review)
        {
            //þarf að útfæra
            return View();
        }
    }
}