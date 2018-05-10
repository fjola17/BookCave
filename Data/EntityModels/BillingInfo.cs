namespace BookCave.Data.EntityModels
{
    public class BillingInfo
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Adress{ get; set; }
        public string PhoneNumber { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string CardNumber { get; set; }
    }
}