using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class AuthorDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public List<BookViewModel> BooksWritten { get; set; }
    }
}