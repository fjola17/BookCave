using Microsoft.AspNetCore.Identity;
using BookCave.Models;

namespace BookCave.Models.InputModels
{
    public class FeedbackInputModel
    {
        public int Id { get; set; }
        public UserManager<ApplicationUser> UserName { get; set; }
        public string Message { get; set; }

    }
}