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
        [Required(ErrorMessage = "Invalid password.")]
        public string Password { get; set; }
        [Compare ("Password", ErrorMessage = "Confirm password doesn't match, please insert matching passwords.")]
        public string ConfirmPassword { get; set; }
        public string Image { get; set; }
        
        public string FavoriteBook { get; set; }
        
        public string Address { get; set; }
        public bool IAgree { get{return true;} }
        [Compare("IAgree",ErrorMessage ="You need to agree to our terms to be able to use Bookcave.")]
        public bool TermsAndAgreement { get; set; }
    }
}