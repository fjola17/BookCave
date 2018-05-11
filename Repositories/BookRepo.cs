using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System;
using BookCave.Models.InputModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {

        private DataContext _db;

        public BookRepo() 
        {
            _db = new DataContext();
        }
        //Nær í forsíðu
        public List<BookViewModel> GetBookIndex()
        {
            var rand = new Random();
            //velur random bækur úr gagnagrunni
            var bookList = (from bo in _db.Books
                            orderby rand.Next()
                            select new BookViewModel
                            {
                                Id = bo.Id,
                                Title = bo.Title,
                                Author = bo.Author,
                                PublishingYear = bo.PublishingYear,
                                Description = bo.Description,
                                Genre = bo.Genre,
                                Rating = bo.Rating,
                                Price = bo.Price,
                                Formats = bo.Formats,
                                AudioSample = bo.AudioSample,
                                CoverImage = bo.CoverImage
                            }).Take(20).ToList();
            return bookList;
        }
        //býr til lita af eftir 'Genre'
        public List<BookViewModel> GetByGenre(string genre)
        {
            var filteredbygenre = (from bo in _db.Books
                                where bo.Genre == genre
                                orderby bo.Title
                                select new BookViewModel
                                {
                                    Id = bo.Id,
                                    Title = bo.Title,
                                    Author = bo.Author,
                                    PublishingYear = bo.PublishingYear,
                                    Description = bo.Description,
                                    Genre = bo.Genre,
                                    Rating = bo.Rating,
                                    Price = bo.Price,
                                    Formats = bo.Formats,
                                    AudioSample = bo.AudioSample,
                                    CoverImage = bo.CoverImage
                                }).ToList();
            return filteredbygenre;
        }
        public List<BookViewModel> GetBySearchString(string searchString)
        {

            var booksfiltered = (from bo in _db.Books
                        where bo.Title.ToLower().Contains(searchString.ToLower()) || bo.Author.ToLower().Contains(searchString.ToLower())
                        orderby bo.Title
                        select new BookViewModel
                        {
                            Id = bo.Id,
                            Title = bo.Title,
                            Author = bo.Author,
                            PublishingYear = bo.PublishingYear,
                            Description = bo.Description,
                            Genre = bo.Genre,
                            Rating = bo.Rating,
                            Price = bo.Price,
                            Formats = bo.Formats,
                            AudioSample = bo.AudioSample,
                            CoverImage = bo.CoverImage
                        }).ToList();

            return booksfiltered;
            
        }
        public BookDetailsViewModel GetById(int? bookId)
        {
            var book = (from bo in _db.Books
                    where bo.Id == bookId
                    select new BookDetailsViewModel
                    {
                        Id = bo.Id,
                        Title = bo.Title,
                        Author = bo.Author,
                        PublishingYear = bo.PublishingYear,
                        Description = bo.Description,
                        Genre = bo.Genre,
                        Rating = bo.Rating,
                        Price = bo.Price,
                        Formats = bo.Formats,
                        AudioSample = bo.AudioSample,
                        CoverImage = bo.CoverImage
                    }).SingleOrDefault();
                    var reviews = (from rw in _db.Reviews
                   where rw.BookId == bookId
                   select new ReviewViewModel
                   {
                       UserId = rw.UserId, //Notandi sem á review
                       BookId = rw.BookId, //current bók
                       ActualReview = rw.ActualReview,
                       Rating = rw.Rating

                   }).ToList();
                   if(book == null)
                   {
                       return book;
                   }
            book.Reviews = reviews;
            if(book.Reviews.Count == 0)
            {
                book.Rating = 3;
            }
            else
            {
                double aggregatedRating = 0;
                int revCount = 0;
                foreach(var rev in reviews)
                {
                    revCount++;
                    aggregatedRating += rev.Rating;
                }
                book.Rating = aggregatedRating / revCount;
            }
            
            return book;
        }
        public List<BookViewModel> TopRatedBooks()
        {
            var bookList = (from bo in _db.Books
                            orderby bo.Rating descending
                            select new BookViewModel
                            {
                                Id = bo.Id,
                                Title = bo.Title,
                                Author = bo.Author,
                                PublishingYear = bo.PublishingYear,
                                Description = bo.Description,
                                Genre = bo.Genre,
                                Rating = bo.Rating,
                                Price = bo.Price,
                                Formats = bo.Formats,
                                AudioSample = bo.AudioSample,
                                CoverImage = bo.CoverImage
                            }).Take(10).ToList();
            return bookList;
        }
        //Sendi skilaboð á notanda síðunnar
        public bool SendFeedback(FeedbackInputModel feedback, string userId)
        {
            var feed = new Feedback
            {
                UserId = userId,
                Message = feedback.Message
            };
            if(feed == null)
            {
                return false;
            }
            _db.Feedbacks.Add(feed);
            _db.SaveChanges();
            return true;
        }

    }
}