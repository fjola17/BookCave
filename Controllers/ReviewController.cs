using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using BookCave.Models;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore.Authorization;
//using BookCave.Services

namespace BookCave.Controllers
{
    public class ReviewController : Controller
    {
        public ReviewRepo _reviewServices;
        private readonly UserManager<ApplicationUser> _userManager;

        
        public ReviewController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _reviewServices = new ReviewRepo();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ReviewInputModel review) //Býr til review
        {
            if(review.Rating == 0)
            {
                ViewData["ErrorMessage"] = "Failed to create review";
                return RedirectToAction("Details", "Book", review.BookId);
            }
            var userId = _userManager.GetUserId(User);
            var new_review = new Review() { UserId = userId, BookId = review.BookId, ActualReview = review.ActualReview, Rating = review.Rating};
            _reviewServices.Create(new_review);
            ViewData["SucessMessage"] = "Review was created sucessfully!!";
            return Ok();
        }
    }
}