using System.ComponentModel.DataAnnotations;
namespace BookCave.Models.ViewModels
{
    public class EditViewModel
    {
        
        
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public string Image { get; set; }
        
        public string FavoriteBook { get; set; }
        
        public string Address { get; set; }
    }
}