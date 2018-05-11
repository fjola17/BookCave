using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class ProcessOrderViewModel
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }        
        public string BillingName { get; set; }
        public string BillingCountry { get; set; }
        public string BillingCity { get; set; }
        public string BillingAdress { get; set; }
        public string Zip { get; set; }
        public string PaymentMethod { get; set; }
        public double TotalPrice { get; set; }
        public List<BookCartViewModel> Books { get; set; }
        
    }
}
 