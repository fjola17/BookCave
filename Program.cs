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
            ///SeedData();
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
                new Book{ Title = "Harry Potter and the Philosopher's Stone", Author = "J. K. Rowling", PublishingYear = 1997, Description = "Lorem ipsum dolor",
                          Genre = "Fantasy", Rating = 4.9, Price = 20, Formats = "Hard-cover, AudioBook and Kindle", AudioSample = "adfskjgnjksfsdkhlgsdj",
                          CoverImage = "https://static.independent.co.uk/s3fs-public/styles/article_small/public/thumbnails/image/2016/02/26/13/3-Harry-Potter-and-the-Philosophers-Stone.jpg" },
                
                new Book{ Title = "Harry Potter and the Chamber of Secrets", Author = "J. K. Rowling", PublishingYear = 1998, Description = "Lorem ipsum dolor",
                          Genre = "Fantasy", Rating = 4.8, Price = 20, Formats = "Hard-cover, AudioBook and Kindle", AudioSample = "adfskjgnjksfsdkhlgsdj",
                          CoverImage = "https://images-na.ssl-images-amazon.com/images/P/0613287142.jpg" },

                new Book{ Title = "Harry Potter and the Prisoner of Azkaban", Author = "J. K. Rowling", PublishingYear = 1999, Description = "Lorem ipsum dolor",
                          Genre = "Fantasy", Rating = 5, Price = 20, Formats = "Hard-cover, AudioBook and Kindle", AudioSample = "adfskjgnjksfsdkhlgsdj",
                          CoverImage = "http://cdn.shopify.com/s/files/1/2597/5112/products/hpbthc03_0378c495-1be0-47a7-ac92-12d692b9115c_1024x1024.jpg?v=1517443130" }
            };
            
            db.AddRange(initialBooks);
            db.SaveChanges();
            }
        }
    }
}
