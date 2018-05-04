using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {

        private DataContext _db;

        public BookRepo() 
        {
            _db = new DataContext();
        }

        public List<BookViewModel> GetBookIndex()
        {
            var bookList = (from bo in _db.Books
                            select new BookViewModel
                            {
                                Id = bo.Id,
                                Title = bo.Title,
                                PublishingYear = bo.PublishingYear,
                                Description = bo.Description,
                                Genre = bo.Genre,
                                Rating = bo.Rating,
                                Price = bo.Price,
                                Formats = bo.Formats,
                                AudioSample = bo.AudioSample,
                                CoverImage = bo.CoverImage
                            }).ToList();
            return bookList;
        }

        public List<BookViewModel> GetBySearchString(string searchString)
        {
            var bookList = (from bo in _db.Books
                            where bo.Title == searchString
                            orderby bo.Title
                            select new BookViewModel
                            {
                                Id = bo.Id,
                                Title = bo.Title,
                                PublishingYear = bo.PublishingYear,
                                Description = bo.Description,
                                Genre = bo.Genre,
                                Rating = bo.Rating,
                                Price = bo.Price,
                                Formats = bo.Formats,
                                AudioSample = bo.AudioSample,
                                CoverImage = bo.CoverImage
                            }).ToList();

            return bookList;
        }
        public BookViewModel GetById(int bookId)
        {
            //eftir að útfæra
            var book = (from bo in _db.Books
                    where bo.Id == bookId
                    select new BookViewModel 
                    {
                        Id = bo.Id,
                        Title = bo.Title,
                        PublishingYear = bo.PublishingYear,
                        Description = bo.Description,
                        Genre = bo.Genre,
                        Rating = bo.Rating,
                        Price = bo.Price,
                        Formats = bo.Formats,
                        AudioSample = bo.AudioSample,
                        CoverImage = bo.CoverImage
                    }).SingleOrDefault();

            return book;
        }
        public bool Update(int bookId)
        {
            //útfæra
            return true;
        }
        public bool Delete(int bookId)
        {
            //útfæra
            return false;
        }
        public bool Create(int bookId)
        {
            //útfæra
            return true;
        }

    }
}