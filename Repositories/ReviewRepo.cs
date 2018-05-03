using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class ReviewRepo
    {
        private DataContext _db;
        public ReviewRepo() 
        {
            _db = new DataContext();
        }
        public List<ReviewViewModel> GetOwnerId(int reviewId)
        {
            //þarf að útfæra
            var owner = (from rv in _db.Reviews
                        select new ReviewViewModel
                        {

                        }).ToList();
            
            return owner;
        }
        public ReviewViewModel GetById(int reviewId)
        {
            //þarf að útfæra
            var review = (from rv in _db.Reviews
                        select rv).SingleOrDefault();
            
            return review;
        }
        public bool Create(ReviewViewModel rv)
        {
            return true;
        }
    }
}