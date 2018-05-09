using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Models.ViewModels;
using BookCave.Data;
using Microsoft.AspNetCore.Identity;
using BookCave.Models;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private DataContext _db ;

        public OrderRepo() 
        {
            _db = new DataContext();
        }
        public List<OrderViewModel> GetByOwnerId()
        {
            //Ath hvernig á að birta bækur??
            var ordersFromOwner = (from ord in _db.Orders
                                   orderby ord.OrderId
                                   select new OrderViewModel
                                   {
                                      OwnerId = ord.OwnerId,
                                      Paid = ord.Paid,
                                      TotalPrice = ord.TotalPrice
                                    }).ToList();
            return ordersFromOwner;
        }
        /* 
         public OrderDetailsViewModel GetById(int? id)
        {
            var aOrder = (from ord in _db.Orders
                        where ord.OrderId == id 
                        //líkleg join hér sem á eftir að útfæra
                        join cob in _db.BookInCarts on ord.OrderId equals cob.CartId
                        join bk in _db.Books on cob.BookId equals bk.Id
                        select new OrderDetailsViewModel() //Hér eiga allar bækurnar að koma upp
                        {
                            OwnerId = ord.OwnerId,
                            OrderId = ord.OrderId,
                            Paid = ord.Paid,
                            TotalPrice = ord.TotalPrice
                        }).SingleOrDefault();
            var booksInorder = (from bks in _db.Books
                                
                                select new BookViewModel
                                {
                                    Title = bks.Title,
                                    PublishingYear = bks.PublishingYear,
                                    Description = bks.Description,
                                    Genre = bks.Genre,
                                    Rating = bks.Rating,
                                    Price = bks.Price,
                                    Formats = bks.Formats,
                                    AudioSample = bks.AudioSample,
                                    CoverImage = bks.CoverImage
                                }).ToList();
            //virkar öruglega ekki því það vantar tengingu við gagnagrunn
           
            return aOrder;
        }
        */
       /* public void ClearCart(CartViewModel cart)
        {
            //hreynsar allt út úr körfunni
            if(cart == null)
            {
                return;
            }
        }
        
        public bool DeleteById(int? orderId)
        {
            if(orderId == null)
            {
                return false;
            }
            int cartId = GetCart();
            //leita af bókinni 
            var bookTodelete = (from bks in _db.BookInCarts
                                where bks.Id == orderId
                                select bks).SingleOrDefault();
            _db.BookInCarts.Remove(bookTodelete);
            _db.SaveChanges();
            return true;
            
        }
      */  
        public bool Buy(OrderViewModel owm)
        {
            return true;
        }
       /* public OrderDetailsViewModel Cart()
        {
            var cart = (from ca in _db.Orders
            select new OrderDetailsViewModel
            {
                OrderId = ca.OrderId,
                OwnerId = ca.OwnerId,
                Paid = ca.Paid
            }).SingleOrDefault();
            var booksInCart = (from bks in _db.Books
            join bksc in _db.BookInCarts on bks.Id equals bksc.BookId
            join ord in _db.Orders on bksc.CartId equals ord.OrderId
            select new BookViewModel{
                Title = bks.Title,
                CoverImage = bks.CoverImage,
                Price = bks.Price
            }).ToList();
            var totalprice = 0.0;
            foreach (var book in cart.BooksInOrder)
            {
                totalprice += book.Price;
            }
            booksInCart = cart.BooksInOrder;
            totalprice = cart.TotalPrice;
            return cart;

        }*/
        public bool AddToCart(int id)
        {  
            int cartid = GetCart();
            var itemincart = (from it in _db.Orders
                            join bksc in _db.BookInCarts on it.OrderId equals bksc.CartId
                            join bok in _db.Books on bksc.BookId equals bok.Id
                            where it.Paid == false && id == bok.Id
            select bksc).SingleOrDefault();
            if(itemincart == null)
            {
               //býr til nýjan tengistreng ef bókin er ekki í körfu
               itemincart = new BookInCart
               {
                   BookId = id,
                   OwnerId = itemincart.OwnerId,
                   CartId = itemincart.CartId,
                   CountOfBooks = 1
               };
               _db.BookInCarts.Add(itemincart);
            }
            else
            {
                itemincart.CountOfBooks++;
            }
            _db.SaveChanges();
            return true;
        }
        public int GetCart()
        {
            return 1;
        }
    }
}