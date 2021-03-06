namespace BookCave.Models.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishingYear { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public string Formats { get; set; }
        public string AudioSample { get; set; }
        public string CoverImage { get; set; }
    }
}