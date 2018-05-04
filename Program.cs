using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BookCave.Data;
using BookCave.Data.EntityModels;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
          //  SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()//Sendir gögn inn í gagnagrunninn
        {
            var db = new DataContext();

            if(!db.Books.Any())
            {
            var initialBooks = new List<Book>()
            {
                new Book{ Title = "Harry Potter and the Goblet of Fire", Author = "J. K. Rowling", PublishingYear = 2000, Description = "Lorem ipsum dolor",
                          Genre = "Fantasy", Rating = 4, Price = 20, Formats = "Hard-cover, AudioBook and Kindle", AudioSample = "adfskjgnjksfsdkhlgsdj",
                          CoverImage = "https://www.teachervision.com/sites/default/files/fe_slideshow/2007_07/HPusa4_TV.jpg" },
                new Book{ Title = "Harry Potter and the Order of the Pheonix", Author = "J. K. Rowling", PublishingYear = 2001, Description = "Lorem ipsum dolor",
                          Genre = "Fantasy", Rating = 4.5, Price = 20, Formats = "Hard-cover, AudioBook and Kindle", AudioSample = "adfskjgnjksfsdkhlgsdj",
                          CoverImage = "https://images-na.ssl-images-amazon.com/images/I/51XDBEZFD1L._SX322_BO1,204,203,200_.jpg" }
            };
            
            db.AddRange(initialBooks);
            db.SaveChanges();
            }
        }
    }
}
