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
        public IActionResult Index() //Displays all orders for a logged in user
        { 
            var allOrderFromusers = _orderServices.GetByOwnerId().ToList();
            
            return View(allOrderFromusers);
        }
        public IActionResult Details(int? id)
        { 
            if(id == null)
            {
                return View("Error");
            }
            var orders = _orderServices.GetById(id);
            if(orders == null)
            {
                return View("Error");
            }
            return View(orders);
        }
        


        [HttpPost]
        public IActionResult Create(OrderViewModel booksToBuy)
        {
            
            return View();
        }

        [HttpDelete] //veit ekki hvort þetta eigi að vera hér
        public IActionResult Delete(int ISBN)
        {
            //Þarf að útfæra betur, nota Ajax
            return View();
        }
        [HttpGet]
        public IActionResult Buy(OrderViewModel bookTobuy)
        {
            //Þarf að útfæra betur
            var buybooks = _orderServices.Buy(bookTobuy);
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            if(!ModelState.IsValid)
            {
                RedirectToAction("Login");
            }
            var addBookToCart = _orderServices.AddToCart(id);
            return View("Cart", "Order");
        }
        public IActionResult Cart()
        {
            //er bara að skoða körfu
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}