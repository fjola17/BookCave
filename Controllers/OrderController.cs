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
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel booksToBuy)
        {
            //Þarf að útfæra betur
            return View();
        }
        [HttpDelete] //veit ekki hvort þetta eigi að vera hér
        public IActionResult Delete(int ISBN)
        {
            //Þarf að útfæra betur
            return View();
        }
        [HttpGet]
        public IActionResult Buy(OrderViewModel bookTobuy)
        {
            //Þarf að útfæra betur
            return View();
        }
    }
}