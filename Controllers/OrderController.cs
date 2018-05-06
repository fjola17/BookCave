using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using BookCave.Models;
//using BookCave.Services

namespace BookCave.Controllers
{
    public class OrderController : Controller
    {
        public OrderRepo _orderServices; 
        public OrderController()
        {
            _orderServices = new OrderRepo();
        }
        public IActionResult Index() //Displays all orders for the certain user
        {/* 
            if(id == null)
            {
                return View("Error");
            }
            var allOrderFromusers = _orderServices.GetByOwnerId(id).ToList();
            if(allOrderFromusers == null)
            {
                return View("Error");
            }
            return View(allOrderFromusers);*/
            return View();
        }
        public IActionResult Details(int? id)
        {/* 
            if(id == null)
            {
                return View("Error");
            }
            var orders = _orderServices.GetById(id);
            if(orders == null)
            {
                return View("Error");
            }
            return View(orders);*/
            return View();
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}