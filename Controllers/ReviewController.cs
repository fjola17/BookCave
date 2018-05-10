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
//using BookCave.Services

namespace BookCave.Controllers
{
    public class ReviewController : Controller
    {
        public ReviewRepo _reviewServices;
        public ReviewController()
        {
            _reviewServices = new ReviewRepo();
        }
    
        private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult BookReviews(int bookId) //Nær í reviews fyrir bók
        {
            var reviewsByBookId = _reviewServices.GetByBookId(bookId);
            if(reviewsByBookId == null)
            {
                return View();
            }
            return View(reviewsByBookId);
        }
        public IActionResult UserReviews(string ownerId) //Nær í review eftir notanda
        {

            var reviewsByOwnerId = _reviewServices.GetByOwnerId(ownerId);
            if(reviewsByOwnerId == null)
            {
                return View();
            }
            return View(reviewsByOwnerId);
        }
        public IActionResult SingleReview(int reviewID) //Nær í ákveðið review(nánari upplýsingar)
        {
            var reviewsById = _reviewServices.GetByReviewId(reviewID);
            if(reviewID == 0)
            {
                return View();
            }
            return View(reviewsById);
        }

        [HttpPost]
        public IActionResult Create(ReviewInputModel review) //Býr til review
        {
            if(review.Rating == 0)
            {
                ViewData["ErrorMessage"] = "Failed to create review";
                return RedirectToAction("Details", "Book", review.BookId);
            }
            var userId = _userManager.GetUserId(User);
            var new_review = new Review() { UserId = userId, BookId = review.BookId, ActualReview = review.ActualReview};
            
            var newReview = _reviewServices.Create(new_review);
            ViewData["SucessMessage"] = "Review was created sucessfully!!";
            return RedirectToAction("Book","Details", new{id = review.BookId});
        }
    }
}