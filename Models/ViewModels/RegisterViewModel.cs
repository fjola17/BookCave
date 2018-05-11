using System.ComponentModel.DataAnnotations;
namespace BookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Invalid email." )]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Invalid password. Must contain Uppercase [ABC], lowercase [abc], numerical[123] and special characters [!?#].")]
        public string Password { get; set; }
        public string Image { get; set; }
        
        public string FavoriteBook { get; set; }
        
        public string Address { get; set; }
        [Required(ErrorMessage = "You need to agree to our terms to be able to use Bookcave.")]
        public bool TermsAndAgreement { get; set; }
    }
}