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
    public class ReviewController : Controller
    {
        private ReviewRepo _reviewServices;

        public IActionResult BookReviews(int bookId) //Nær í reviews fyrir bók
        {
            var reviewsByBookId = _reviewServices.GetByBookId(bookId);
            return View(reviewsByBookId);
        }
        public IActionResult UserReviews(int ownerId) //Nær í review eftir notanda
        {
            var reviewsByOwnerId = _reviewServices.GetByOwnerId(ownerId);
            return View(reviewsByOwnerId);
        }
        public IActionResult SingleReview(int reviewID) //Nær í ákveðið review(nánari upplýsingar)
        {
            var reviewsById = _reviewServices.GetByReviewId(reviewID);
            return View(reviewsById);
        }
        public IActionResult Create(ReviewViewModel review) //Býr til review
        {
            //þarf að útfæra
            return View();
        }
    }
}