using Microsoft.AspNetCore.Identity;
using BookCave.Models;

namespace BookCave.Models.InputModels
{
    public class FeedbackInputModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }

    }
}