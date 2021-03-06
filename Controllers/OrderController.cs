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
    [Authorize]
    public class OrderController : Controller
    {
        public OrderRepo _orderServices;
         private readonly UserManager<ApplicationUser> _userManager;
         
        public OrderController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _orderServices = new OrderRepo();   
        }
        //Skoðar allar pantanir út frá tilteknum notanda
        public IActionResult Index()
        { 
            var userId = _userManager.GetUserId(User);
            var allOrderFromusers = _orderServices.GetByOwnerId(userId);
            
            return View(allOrderFromusers.ToList());
        }
        //Fær upplýsingar um ákveðna pöntun
        //Virkar ekki!!
        public IActionResult Details(int? id)
        { 
            if(ModelState.IsValid)
            {
                return View("Error");
            }
            var userId = _userManager.GetUserId(User);
            var orders = _orderServices.GetById(id, userId);
            if(orders == null)
            {
                return View("NotFound");
            }
            return View(orders);
        }
        //Eyðir úr körfu
        public IActionResult Delete(int? ISBN)
        {
            //Þarf að útfæra betur
            if(!ModelState.IsValid)
            {
                return View("NotFound");
            }
            var userId = _userManager.GetUserId(User);
            var cart =_orderServices.GetCart(userId);
            if(_orderServices.DeleteById(ISBN, cart, userId))
            {
                ViewBag.Title = "Error";
                return View("Error");
            }
           // var displaycart = _orderServices.Cart(userId, cart);
            return RedirectToAction("Cart");
        }
        //bætir við í körfuna
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
                return View("Error");
            }
            ViewBag.Title = "Sucess!";
            return RedirectToAction("Cart", "Order");

        }
        //karfan
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
                return RedirectToAction("AccessDenied", "Account");
            }
            var user = _userManager.GetUserId(User);
            var cartId = _orderServices.GetCart(user);
            //if ()
            if(!_orderServices.ShippingInfo(shipping, user, cartId))
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            return RedirectToAction("BillingInfo");
        }
        [HttpGet]
        public IActionResult BillingInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BillingInfo(BillingInputModel billing)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user = _userManager.GetUserId(User);
            var cartId = _orderServices.GetCart(user);
            if(!_orderServices.BillingInfo(billing, user, cartId))
            {
                return View("Error");
            }
            return RedirectToAction("ReviewOrder");
        }
        public IActionResult ReviewOrder()
        {
            if(!ModelState.IsValid)
            {
                return View("Error");
            }
            var user = _userManager.GetUserId(User);
            var cartId = _orderServices.GetCart(user);
            //birtir bara það sem er í körfunni

            var order = _orderServices.ViewOrder(cartId, user);
            if(order == null)
            {
                return View("Error");
            }
            return View(order);            
        }

        public IActionResult Buy()
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Cart");
            }
            var user = _userManager.GetUserId(User);
            var cartId = _orderServices.GetCart(user);
            if(!_orderServices.Buy(user, cartId))
            {
                return RedirectToAction("FrontPage", "Home");
            }
            return RedirectToAction("FrontPage","Home");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}