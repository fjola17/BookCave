namespace BookCave.Data.EntityModels
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string ActualReview { get; set; }
        public int Rating { get; set; }
    }
}