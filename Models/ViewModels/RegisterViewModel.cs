using System.ComponentModel.DataAnnotations;
namespace BookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Invalid email" )]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Invalid password")]
        public string Password { get; set; }
        public string Image { get; set; }
        
        public string FavoriteBook { get; set; }
        
        public string Address { get; set; }
    }
}