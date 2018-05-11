using Microsoft.AspNetCore.Identity;
using BookCave.Models;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class FeedbackInputModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage="Need to put in a title")]
        public string Message { get; set; }

    }
}