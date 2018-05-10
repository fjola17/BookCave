using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class ProcessOrderViewModel
    {
        public int Id { get; set; } 
        public string FullName { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Adress{ get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public List<BookCartViewModel> Books { get; set; }
        public int TotalPrice { get; set; }
    }
}
 