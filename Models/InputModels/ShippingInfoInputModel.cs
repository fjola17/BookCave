using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class ShippingInfoInputModel
    {
         public int Id { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }
        [Required(ErrorMessage= "You need to put your name here")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "You need to select a country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "You need to enter your Zipcode")]
        public string Zipcode { get; set; }
        [Required(ErrorMessage="You need to enter your city")]
        public string City { get; set; }
        [Required(ErrorMessage ="You need enter your Address")]
        public string Adress{ get; set; }
        [Required(ErrorMessage="Please enter a valid phone number")]
        //[RegularExpression]
        public string PhoneNumber { get; set; }
    }
}