using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class CartViewModel
    {
        public int OwnerId { get; set; }
        public List<BookViewModel> BooksInCart { get; set; }
        public int TotalPrice { get; set; }
    }
    

}