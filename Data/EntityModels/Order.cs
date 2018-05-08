using System.Collections.Generic;

namespace BookCave.Data.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OwnerId { get; set; }
        public bool Paid { get; set; }
        public double TotalPrice { get; set; }
    }
}