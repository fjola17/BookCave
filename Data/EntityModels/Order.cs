using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Data.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; } //vantar identity fyrir order
        public bool Paid { get; set; }
        public double TotalPrice { get; set; }
    }
}