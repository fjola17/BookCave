namespace BookCave.Data.EntityModels
{
    //To get information about an user
    public class ShippingInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}