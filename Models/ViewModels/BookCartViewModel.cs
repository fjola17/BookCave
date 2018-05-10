namespace BookCave.Models.ViewModels
{
    public class BookCartViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BookId { get; set; }
        public string CoverImage { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}