namespace BookCave.Data.EntityModels
{
    public class BooksInCart
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }

    }
}