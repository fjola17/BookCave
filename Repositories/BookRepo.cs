using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        public List<Book> getBySearchString(string searchString)
        {
            var bookList = (from bo in Book
                            where bo.Title == searchString
                            orderby bo.Title
                            select bo).ToList();

            return bookList;
        }
        public Book GetById(int bookId)
        {
            //eftir að útfæra
            var book = (from bo in Book
                    where bo.Id == bookId
                    select bo).singleOrDefault();

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