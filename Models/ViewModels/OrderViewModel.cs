using Microsoft.AspNetCore.Identity;

namespace BookCave.Models.ViewModels
{
    //Þarf kanski að skoða pínu betur
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int OrderId { get; set; }
        public bool Paid { get; set; }
        public double TotalPrice { get; set; }
    }
}