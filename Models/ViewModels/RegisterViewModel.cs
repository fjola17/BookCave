using System.ComponentModel.DataAnnotations;
namespace BookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Invalid email" )]
        [EmailAddress]
        public string Email { get; set; }
      //  [Required(ErrorMessage = "Invalid username")]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Invalid password")]
        public string Password { get; set; }
    }
}