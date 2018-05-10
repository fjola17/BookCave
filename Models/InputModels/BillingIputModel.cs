using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class BillingInputModel
    {
        
        public int Id { get; set; }
/*        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You need to select a country")]
        public string Country { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required(ErrorMessage = "Need to put in city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Need to input adress")]
        public string Address{ get; set; }*/
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please pick your payment method")]
        public string PaymentMethod { get; set; }
        [Required(ErrorMessage="Invalid card number")]
        public string CardNumber { get; set; }
    }
}