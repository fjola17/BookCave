using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Data;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;

namespace BookCave.Repositories
{
    public class ReviewRepo
    {
        private DataContext _db;
        public ReviewRepo() 
        {
            _db = new DataContext();
        }
        public List<ReviewViewModel> GetByBookId(int bookId) //Nær í review tengd þessarri bók
        {
            var bookReviews = (from rv in _db.Reviews
                         where rv.BookId == bookId
                         select new ReviewViewModel
                        {
                            Id = rv.Id,
                            OwnerId = rv.OwnerId,
                            BookId = rv.BookId,
                            ActualReview = rv.ActualReview,
                            Rating = rv.Rating
                        }).ToList();
            
            return bookReviews;
        }
        public List<ReviewViewModel> GetByOwnerId(int ownerId) //Nær í review tengd þessum notanda
        {
            var ownerReviews = (from rv in _db.Reviews
                         where rv.OwnerId == ownerId
                         select new ReviewViewModel
                        {
                            Id = rv.Id,
                            OwnerId = rv.OwnerId,
                            BookId = rv.BookId,
                            ActualReview = rv.ActualReview,
                            Rating = rv.Rating
                        }).ToList();
            
            return ownerReviews;
        }
        public ReviewViewModel GetByReviewId(int reviewId) //Nær í ákveðið review
        {
            var review = (from rv in _db.Reviews
                          where rv.Id == reviewId
                          select new ReviewViewModel
                          {
                            Id = rv.Id,
                            OwnerId = rv.OwnerId,
                            BookId = rv.BookId,
                            ActualReview = rv.ActualReview,
                            Rating = rv.Rating
                          }).SingleOrDefault();
            
            return review;
        }
        public bool Create(ReviewInputModel rv)
        {
            
            var reviewToAdd = new Review()
            {
                OwnerId = rv.OwnerId,
                BookId = rv.BookId,
                ActualReview = rv.ActualReview,
                Rating = rv.Rating
            };
            _db.Add(reviewToAdd);
            _db.SaveChanges();

            return true;
        }
    }
}