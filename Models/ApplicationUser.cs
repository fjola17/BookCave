using Microsoft.AspNetCore.Identity;

namespace BookCave.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string Image { get; set; }
        public string FavoriteBook { get; set; }
    }
}