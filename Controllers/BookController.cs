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
        public BookController()
        {
            _bookServices = new BookRepo();
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
        public IActionResult Details(int? id) //Nær í details fyrir eina bók með id
        {
            if(id == null) //Gleimir að skrá inn bók þarf að höndla
            {
                return View("Error");
            }
            var book = _bookServices.GetById(id);
            if(book == null) //bók finnst ekki, þarf að höndla villurnar
            {
                return View("Error");
            }
            return View(book);
        }
        public IActionResult SearchBooks(string searchString) //Nær í bækur eftir searchstring en bara eftir titli núna, virkar ekki!!
                                                        ///þarf að útfæra með fleiri eigindi
        {
            if(searchString == null)
            {
                return View("Index"); //birtir allar bækurnar ef ítt er á search án þess að skrifa neitt
            }
            var booksFound = _bookServices.GetBySearchString(searchString);
            return View(booksFound);
        }

    }
}
