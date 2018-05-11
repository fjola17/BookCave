using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookService : ErrorService
    {
        private BookRepo _bookRepo { get; set; }
        public BookService()
        {
            _bookRepo = new BookRepo();
        }
        public List<BookViewModel> GetBookIndex()
        {
            var items = _bookRepo.GetBookIndex();
            if(items == null)
            {
        //        throw Exection();
            }
            return items;
        }
        public List<BookViewModel> GetByGenre(string genre)
        {
            var books =_bookRepo.GetByGenre(genre);
            return books;
        }
        public List<BookViewModel> GetBySearchString(string searchString)
        {
            var filter = _bookRepo.GetBySearchString(searchString);
            return filter;
        }
        public BookDetailsViewModel GetById(int? bookId)
        {
            if(bookId == null)
            {
         //       throw Exception();
            }
            var booksById = _bookRepo.GetById(bookId);
            if(booksById == null)
            {
        //        throw Exception();
            }
            return booksById;
        }
        public List<BookViewModel> TopRatedBooks()
        {
            var highest = _bookRepo.TopRatedBooks();
            return highest;
        }
        public void SendFeedback(FeedbackInputModel feedback)
        {
           // _bookRepo.SendFeedback(feedback);
        }
    }
}