using BookCave.Models;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Data.EntityModels
{
    public class Feedback
    {
        public int Id { get; set; }
        public UserManager<ApplicationUser> UserName { get; set; }
        public string Message { get; set; }

    }
}