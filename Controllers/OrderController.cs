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
    public class OrderController : Controller
    {
        private OrderRepo _orderServices; 
        OrderController(OrderRepo orderServices)
        {
            _orderServices = orderServices;
        }
        public IActionResult Details(int id)
        {
            
            var orders = _orderServices.GetById(id);
            return View(orders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel booksToBuy)
        {
            if(!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Error!";
                return View();
            }
            _orderServices.Create(booksToBuy);
            ViewData["SucessMessage"] = "Sucess!";
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