using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Data.EntityModels;
using BookCave.Repositories;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookRepo _bookServices; 
        public BookController(BookRepo bookServices)
        {
            _bookServices = bookServices;
        }
        public IActionResult FrontPage()
        {
            var books = _bookServices.GetBookIndex();
            return View(books);
        }  
        public IActionResult BookIndex() //Nær í lista af öllum bókum.
        {
            var books = _bookServices.GetBookIndex();
            return View(books);
        }
        public IActionResult Details(int id) //Nær í details fyrir eina bók með id
        {
            var book = _bookServices.GetById(id);
            return View(book);
        }
        public IActionResult SearchBooks(string searchString) //Nær í bækur eftir searchstring en bara eftir titli núna
                                                        ///þarf að útfæra með fleiri eigindi
        {
            var booksFound = _bookServices.GetBySearchString(searchString);
            return View(booksFound);
        }
    }
}