namespace BookCave.Models.InputModels
{
    public class ShippingInfoInputModel
    {
         public int Id { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Adress{ get; set; }
        public string PhoneNumber { get; set; }
    }
}