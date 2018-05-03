namespace BookCave.Data.EntityModels
{
    public class Order
    {
        public int OwnerId { get; set; }
        public int OrderId { get; set; }
        public bool Paid { get; set; }
        public double Totalprice { get; set; }
    }
}