namespace BookCave.Data.EntityModels
{
    //To get information about an user
    public class ShippingInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Adress{ get; set; }
        public string PhoneNumber { get; set; }
    }
}