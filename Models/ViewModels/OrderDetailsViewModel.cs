using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    //Þarf kanski að skoða pínu betur
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int OrderId { get; set; }
        public bool Paid { get; set; }
        public double TotalPrice { get; set; }
        public List<BookViewModel> BooksInOrder { get; set; }
    }
}