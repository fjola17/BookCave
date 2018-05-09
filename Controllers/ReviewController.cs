using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using BookCave.Models.InputModels;
//using BookCave.Services

namespace BookCave.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewRepo _reviewServices;
<<<<<<< HEAD
       public ReviewController()
=======
        public ReviewController()
>>>>>>> 09b70946aa863c237674e6614ba15430be5c73ee
        {
            _reviewServices = new ReviewRepo();
        }

        public IActionResult BookReviews(int bookId) //Nær í reviews fyrir bók
        {
            var reviewsByBookId = _reviewServices.GetByBookId(bookId);
            return View(reviewsByBookId);
        }
        public IActionResult UserReviews(string ownerId) //Nær í review eftir notanda
        {
            var reviewsByOwnerId = _reviewServices.GetByOwnerId(ownerId);
            return View(reviewsByOwnerId);
        }
        public IActionResult SingleReview(int reviewID) //Nær í ákveðið review(nánari upplýsingar)
        {
            var reviewsById = _reviewServices.GetByReviewId(reviewID);
            return View(reviewsById);
        }

        [HttpPost]
        public IActionResult Create(ReviewInputModel review) //Býr til review
        {
            if(!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Failed to create review";
                return RedirectToAction("Details", "Book");
            }
            var newReview = _reviewServices.Create(review);
            ViewData["SucessMessage"] = "Review was created sucessfully!!";
            return RedirectToAction("Details", "Book");
        }
    }
}