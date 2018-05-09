using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class ReviewInputModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        public string ActualReview { get; set; }
        [Required(ErrorMessage = "You need to rate this book")]
        public int Rating { get; set; }
    }
}