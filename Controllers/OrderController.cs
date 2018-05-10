using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using BookCave.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models.InputModels;

namespace BookCave.Controllers
{
    public class OrderController : Controller
    {
        public OrderRepo _orderServices;
         private readonly UserManager<ApplicationUser> _userManager;
         private readonly SignInManager<ApplicationUser> _SignInManager;
        public OrderController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _SignInManager = signInManager;
            _orderServices = new OrderRepo();   
        }
        public IActionResult Index() //Displays all orders for a logged in user
        { 
            var allOrderFromusers = _orderServices.GetByOwnerId();
            
            return View(allOrderFromusers.ToList());
        }
        /* 
        public IActionResult Details(int? id)
        { 
            if(id == null)
            {
                return View("Error");
            }
            var orders = _orderServices.GetById(id);
            if(orders == null)
            {
                return View("NotFound");
            }
            return View(orders);
        }
*/
        
        public IActionResult Delete(int? ISBN)
        {
            //Þarf að útfæra betur
            if(!ModelState.IsValid)
            {
                return Json("Book could not be deleted");
            }
            var itemToDelete = _orderServices.DeleteById(ISBN);
            
            return Json(itemToDelete);
        }
        [HttpGet]
        public IActionResult Buy(OrderViewModel bookTobuy)
        {
            //Þarf að útfæra betur
            var buybooks = _orderServices.Buy(bookTobuy);
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int bookAdded)
        {
            var userId = _userManager.GetUserId(User);
            var cart =_orderServices.GetCart(userId);
            //Ef karfan finnst ekki einhverra hluta vegna
            if(cart == 0)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            if(!_orderServices.AddToCart(bookAdded, userId, cart))
            {
                ViewBag.Title = "Error";
                return RedirectToAction("Error");
            }
            ViewBag.Title = "Sucess!";
            return RedirectToAction("Cart", "Order");

        }
        [Authorize]
        public IActionResult Cart()
        {
                     //er bara að skoða körfu
            var userId = _userManager.GetUserId(User);
            var cart = _orderServices.GetCart(userId); //finn / bý til cart áður en ég fer inn
            //karfa finnst ekki
            if(cart == 0)
            {
                ViewBag.Title = "Error";
                return View();
            }
            var books = _orderServices.Cart(userId, cart);
            //bækur í körfu finnast ekki
            if(books == null)
            {
                return View("Error");
            }
            return View(books);
        }

        [HttpGet]
        public IActionResult Shipping()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Shipping(ShippingInfoInputModel shipping)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            if(!_orderServices.ShippingInfo(shipping))
            {
                RedirectToAction("AccessDenied", "Account");
            }
            return RedirectToAction("Details");
        }
    }
}