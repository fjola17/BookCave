using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Models.ViewModels
{
    //Þarf kanski að skoða pínu betur
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public bool Paid { get; set; }
        public double TotalPrice { get; set; }
        public List<BookCartViewModel> BooksInOrder { get; set; }
    }
}