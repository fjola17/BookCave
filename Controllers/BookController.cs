using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Data.EntityModels;
using BookCave.Repositories;
using BookCave.Models;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookRepo _bookServices; 
        public BookController()
        {
            _bookServices = new BookRepo();
        }
        
        public IActionResult BookIndex(string searchString) //Nær í lista af öllum bókum.
        {
            //ef ekkert er slegið inn
            if(searchString == null)
            {
                return View("NotFound");
            }
            ViewBag.Title = "searchString";
            var booksFound = _bookServices.GetBySearchString(searchString); //filterar bækur
            //ef ekkert finnst
            if(booksFound.Count == 0)
            {
                ViewBag.Search = searchString;
                return View("NotFound");
            }
            return View(booksFound.ToList());
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
                return View("NotFound");
            }
            return View(book);
        }
        //nær í topp 10
        public IActionResult Top10()
        {
            var top10 = _bookServices.TopRatedBooks();
            return View(top10);
        }
        //leita af bók eftir ákveðnum leitarstreng - genre
        public IActionResult Filter(string genre)
        {
            var filteredByGenre = _bookServices.GetByGenre(genre);
            return View(filteredByGenre);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
