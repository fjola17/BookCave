using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Cart
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public List<Book> BooksInCart { get; set; }
        public int TotalPrice { get; set; }
    }
}