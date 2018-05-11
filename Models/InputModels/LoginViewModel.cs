using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class LoginViewModel
    {   [Required (ErrorMessage="Please insert your account email address.")]
        [EmailAddress ]
        public string Email { get; set; }
        [Required (ErrorMessage="Please insert your account password.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}