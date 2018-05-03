using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;

namespace BookCave.Repositories
{
    public class ReviewRepo
    {
        public List<Review> GetOwnerId(int reviewId)
        {
            //þarf að útfæra
            var owner = (from rv in Review
                        select rv).ToList();
            
            return owner;
        }
        public Review GetById(int reviewId)
        {
            //þarf að útfæra
            var review = (from rv in Review
                        select rv).SingleOrDefault();
            
            return review;
        }
        public bool Create(ReviewViewModel rv)
        {
            return true;
        }
    }
}