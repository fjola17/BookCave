namespace BookCave.Data.EntityModels
{
    public class BookInCart
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CartId { get; set; }
        public int OwnerId { get; set; }
        public int CountOfBooks { get; set; }
    }
}