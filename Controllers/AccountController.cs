using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using System.Security.Claims;

namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(SignInManager<ApplicationUser> signinManager, UserManager<ApplicationUser> userManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //Býr til nýjann account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user = new ApplicationUser
            {
                UserName = register.Email,
                Email = register.Email
                
            };
            var results = await _userManager.CreateAsync(user, register.Password);
            if(results.Succeeded)
            {
                //Notandi er nýskráður
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{register.FirstName} {register.LastName}"));
                await _signinManager.SignInAsync(user, false);
                return RedirectToAction("FrontPage", "Home");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var results = await _signinManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);
            if(results.Succeeded)
            {
                return RedirectToAction("FrontPage", "Home"); //notandi er skráður inn
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("FrontPage", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        
        public IActionResult Profile() 
        {
            return View();
        }
    }
}