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
using Microsoft.AspNetCore.Authorization;

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
                Email = register.Email,
                Address = register.Address,
                Image = register.Image,
                FavoriteBook = register.FavoriteBook
            };
            var results = await _userManager.CreateAsync(user, register.Password);
            if(results.Succeeded)
            {
                //Notandi er nýskráður
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{register.Name}"));
                await _userManager.AddClaimAsync(user, new Claim("Address", $"{register.Address}"));
                await _userManager.AddClaimAsync(user, new Claim("Email", $"{register.Email}"));
                await _userManager.AddClaimAsync(user, new Claim("Image", $"{register.Image}"));
                await _userManager.AddClaimAsync(user, new Claim("FavoriteBook", $"{register.FavoriteBook}"));
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

        [Authorize]
        public IActionResult Profile() 
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit()
        {   
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel updatedProfile)
        {
            if(!ModelState.IsValid) //Skoðar hvort model sé "valid"
            {
                return View("Profile");
            }
            
            if(updatedProfile == null) //Skoðar hvort modelið sem kemur inn sé "valid"
            {
                return View("Profile");
            }

            ApplicationUser user =  _userManager.FindByNameAsync(User.Identity.Name).Result;
            

            if(updatedProfile.Name != null) //Passar að þessi eigindi séu ekki tóm
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == "Name"); //Nær í þetta claim
                await _userManager.RemoveClaimAsync(user, claim); //Eyða gamla claim
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{updatedProfile.Name}")); //Búa til nýtt claim
            }
            if(updatedProfile.Address != null)
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == "Address");
                if(claim != null)//Ef claim er ekki til, þ.e.a.s. er  null, þá á ekki að eyða.
                {
                await _userManager.RemoveClaimAsync(user, claim);
                }
                await _userManager.AddClaimAsync(user, new Claim("Address", $"{updatedProfile.Address}"));
            }
            if(updatedProfile.Image != null)
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == "Image");
                if(claim != null)
                {
                await _userManager.RemoveClaimAsync(user, claim);
                }
                await _userManager.AddClaimAsync(user, new Claim("Image", $"{updatedProfile.Image}"));
            }
            if(updatedProfile.FavoriteBook != null)
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == "FavoriteBook");
                if(claim != null)
                {
                await _userManager.RemoveClaimAsync(user, claim);
                }
                await _userManager.AddClaimAsync(user, new Claim("FavoriteBook", $"{updatedProfile.FavoriteBook}"));
            }
            await _signinManager.SignInAsync(user, false); //Sign-ar user inn aftur svo að síða sé uppfærð
            
            return RedirectToAction("Profile"); //Sendir notanda á profile aftur

        }
    }
}