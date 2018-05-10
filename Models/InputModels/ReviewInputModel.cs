using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class ReviewInputModel
    {
        public int BookId { get; set; }
        public string ActualReview { get; set; }
        public int Rating { get; set; }
    }
}