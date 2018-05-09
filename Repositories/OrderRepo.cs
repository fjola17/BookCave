using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Models.ViewModels;
using BookCave.Data;
using Microsoft.AspNetCore.Identity;
using BookCave.Models;
using System.Security.Claims;
using System;

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
                                    //  OwnerId = ord.OwnerId,
                                      Paid = ord.Paid,
                                      TotalPrice = ord.TotalPrice
                                    }).ToList();
            return ordersFromOwner;
        }
         
         public OrderDetailsViewModel GetById(int? id)
        {
            var aOrder = (from ord in _db.Orders
                        where ord.OrderId == id 
                        //líkleg join hér sem á eftir að útfæra
                        
                        select new OrderDetailsViewModel() //Hér eiga allar bækurnar að koma upp
                        {
                            UserId = ord.UserId,
                            OrderId = ord.OrderId,
                            Paid = ord.Paid,
                            TotalPrice = ord.TotalPrice
                        }).FirstOrDefault();
            var booksInorder = (from bks in _db.Books
                                join cob in _db.BooksInCarts on bks.Id equals cob.BookId
                        join bk in _db.Orders on cob.OrderId equals bk.Id
                                select new BookCartViewModel
                                {
                                    Title = bks.Title,
                                    CoverImage = bks.CoverImage
                                }).ToList();
           
            return aOrder;
        }
        
        public void ClearCart(Order cart)
        {
            //hreynsar allt út úr körfunni
            if(cart == null)
            {
                return;
            }
            cart = new Order
            {
                OrderId = cart.OrderId,
                Paid = false,
            };
            _db.Update(cart);
            _db.SaveChanges();
        }
        
        public bool DeleteById(int? bookId)
        {
            if(bookId == null)
            {
                return false;
            }
            //leita af bókinni í gagnagrunninum
            var bookTodelete = (from bks in _db.BooksInCarts
                                where bks.Id == bookId
                                select new BooksInCart
                                {
                                    Id = bks.Id,
                                    BookId = bks.Id,
                                    Quantity = bks.Quantity,
                                    OrderId = bks.Id,
                                    UserId = bks.UserId
                                }).FirstOrDefault();
            _db.BooksInCarts.Remove(bookTodelete);
            _db.SaveChanges();
            return true;
            
        }
       
        public bool Buy(OrderViewModel owm)
        {
            return true;
        }
        public OrderDetailsViewModel Cart(string userId, Order cartId)
        {
            var cart = (from ca in _db.Orders
                        where ca.Id == cartId.Id && userId == ca.UserId
                        select new OrderDetailsViewModel
                        {
                            Id = cartId.OrderId,
                            UserId = ca.UserId,
                            OrderId = ca.OrderId,
                            Paid = ca.Paid,
                            TotalPrice = ca.TotalPrice
                        }).FirstOrDefault();
            var booksInCart = (from bks in _db.Books
                    join bksc in _db.BooksInCarts on bks.Id equals bksc.BookId
                    join ord in _db.Orders on bksc.OrderId equals ord.Id
                    select new BookViewModel{
                        Title = bks.Title,
                        CoverImage = bks.CoverImage,
                        Price = bks.Price
                    }).ToList();
            if(cart == null)
            {
                return cart;
            }
            cart.BooksInOrder = booksInCart;

            return cart;

        }
        public void AddToCart(int id, string userId, Order cartId)
        {  
            var itemincart = (from it in _db.BooksInCarts              
                            //join ord in _db.Orders on it.OrderId equals ord.Id
                            where it.UserId == userId && id == it.BookId && cartId.Id == it.OrderId
            select new BooksInCart
            {
                Id = it.Id,
                BookId = it.BookId,
                Quantity = it.Quantity,
                OrderId = it.OrderId,
                UserId = it.UserId

            }).FirstOrDefault();
            if(itemincart == null)
            {
                Console.WriteLine("Error");
                return;
            }
            if(itemincart.Id == 0)
            {
               //býr til nýjan tengistreng ef bókin er ekki í körfu
               itemincart = new BooksInCart
               {
                   BookId = id,
                   Quantity = 1,    
                   OrderId = itemincart.Id,
                   UserId = userId,         
               };
               _db.BooksInCarts.Add(itemincart);
            }
            else
            {                
                itemincart.Quantity++;
                _db.BooksInCarts.Update(itemincart);
            }
            _db.SaveChanges();
        }
        public Order GetCart(string id)
        {
            var cart = (from or in _db.Orders
                        where or.UserId == id && or.Paid == false
                        select new Order
                        {
                            OrderId = or.Id,
                            UserId = or.UserId,
                            TotalPrice = or.TotalPrice,
                            Paid = or.Paid
                        }).FirstOrDefault();
            if(cart == null)
            {
                Console.WriteLine("Error");
            }
            else if(cart.Id == 0)
            {
                cart = new Order
                {
                    UserId = id,
                    TotalPrice = 0,
                    Paid = false
                };
                _db.Orders.Add(cart);
                _db.SaveChanges();
            }
              
                
            return cart; 

        }
    }
}