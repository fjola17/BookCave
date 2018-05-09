using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Models.ViewModels
{
    //Þarf kanski að skoða pínu betur
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public bool Paid { get; set; }
        public double TotalPrice { get; set; }
        public List<BookViewModel> BooksInOrder { get; set; }
    }
}