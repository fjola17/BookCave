using System.ComponentModel.DataAnnotations;
namespace BookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Invalid email." )]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Invalid password.")]
        public string Password { get; set; }
        public string Image { get; set; }
        
        public string FavoriteBook { get; set; }
        
        public string Address { get; set; }
        [Required(ErrorMessage = "You need to agree to our terms to be able to use Bookcave.")]
        public bool TermsAndAgreement { get; set; }
    }
}