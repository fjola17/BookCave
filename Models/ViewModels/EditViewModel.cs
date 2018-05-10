using System.ComponentModel.DataAnnotations;
namespace BookCave.Models.ViewModels
{
    public class EditViewModel
    {
        public string Name { get; set; }
        
        public string Image { get; set; }
        
        public string FavoriteBook { get; set; }
        
        public string Address { get; set; }
    }
}