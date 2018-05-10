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
using BookCave.Models.InputModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private DataContext _db ;
        public OrderRepo() 
        {
            _db = new DataContext();
        }
        public List<OrderViewModel> GetByOwnerId(string userId)
        {
            //Ath hvernig á að birta bækur??
            var ordersFromOwner = (from ord in _db.Orders
                                   orderby ord.OrderId descending
                                   select new OrderViewModel
                                   {
                                      Paid = ord.Paid,
                                      TotalPrice = ord.TotalPrice
                                    }).ToList();
            return ordersFromOwner;
        }
         
         public OrderDetailsViewModel GetById(int? id, string userId)
        {
            var aOrder = (from ord in _db.Orders
                        where ord.OrderId == id && ord.Paid == true && ord.UserId == userId
                       select new OrderDetailsViewModel() //Hér eiga allar bækurnar að koma upp
                        {
                            Paid = ord.Paid,
                            TotalPrice = ord.TotalPrice
                        }).FirstOrDefault();
            var booksInorder = (from bks in _db.Books
                                join cob in _db.BooksInCarts on bks.Id equals cob.BookId
                        join bk in _db.Orders on cob.OrderId equals bk.Id
                                join ord in _db.Orders on cob.OrderId equals ord.Id
                                where cob.OrderId == id && ord.Paid == true
                                select new BookCartViewModel
                                {
                                    Title = bks.Title,
                                    CoverImage = bks.CoverImage,
                                    Price = bks.Price,
                                    Quantity = cob.Quantity
                                }).ToList();
            if(aOrder == null)
            {
                Console.WriteLine("OOPS");
                return aOrder; //kasta villu??
            }
            aOrder.BooksInOrder = booksInorder;
            
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
                UserId = cart.UserId,
                Paid = false
            };
            _db.Update(cart);
            _db.SaveChanges();
        }
        
        public bool DeleteById(int? bookId, int cartId, string UserId)
        {
            if(bookId == null)
            {
                return false;
            }
            //leita af bókinni í gagnagrunninum
            var bookTodelete = (from bks in _db.BooksInCarts
                                where bks.Id == bookId && UserId == bks.UserId && cartId == bks.OrderId
                                select new BooksInCart
                                {
                                    Id = bks.Id,
                                    BookId = bks.Id,
                                    Quantity = bks.Quantity,
                                    OrderId = bks.Id,
                                    UserId = bks.UserId
                                }).FirstOrDefault();
            if(bookTodelete == null)
            {
                Console.WriteLine("Error");
                return false;
            }
            _db.BooksInCarts.Remove(bookTodelete);
            _db.SaveChanges();
            return true;
            
        }
       
        public OrderDetailsViewModel Cart(string userId, int cartId)
        {
            var cart = (from ca in _db.Orders
                        where ca.Id == cartId && userId == ca.UserId
                        select new OrderDetailsViewModel
                        {
                            Id = ca.Id,
                            Paid = ca.Paid,
                            TotalPrice = ca.TotalPrice
                        }).FirstOrDefault();
            var booksInCart = (from bks in _db.Books
                    join bksc in _db.BooksInCarts on bks.Id equals bksc.BookId
                    join ord in _db.Orders on bksc.OrderId equals ord.Id
                    where cartId == ord.Id && userId == bksc.UserId
                    select new BookCartViewModel
                    {
                        Id = bksc.Id,
                        Title = bks.Title,
                        BookId = bks.Id,
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
        public bool AddToCart(int id, string userId, int cartId)
        {  
            var itemincart = (from it in _db.BooksInCarts              
                           // join ord in _db.Orders on it.OrderId equals ord.Id
                            where it.UserId == userId && id == it.BookId && cartId == it.OrderId
            select new BooksInCart
            {
                Id = it.Id,
                BookId = id,
                Quantity = it.Quantity,
                OrderId = it.Id,
                UserId =it.UserId

            }).FirstOrDefault();
            if(itemincart == null)
            {
               //býr til nýjan tengistreng ef bókin er ekki í körfu
               itemincart = new BooksInCart
               {
                   BookId = id,
                   Quantity = 1,    
                   OrderId = cartId,
                   UserId = userId,         
               };
               _db.BooksInCarts.Add(itemincart);
            }
            else
            {   
                //ef bókin er þegar til             
                itemincart.Quantity++;
                _db.BooksInCarts.Update(itemincart);
            }
            _db.SaveChanges();
            return true;
        }
        public int GetCart(string id)
        {
            var cart = (from or in _db.Orders
                        where or.UserId == id && or.Paid == false
                        select new Order
                        {
                            Id = or.Id,
                            OrderId = or.Id,
                            UserId = or.UserId,
                            TotalPrice = or.TotalPrice,
                            Paid = or.Paid
                        }).FirstOrDefault();
            if(cart == null)
            {
            
                cart = new Order
                {
                    UserId = id,
                    TotalPrice = 0,
                    Paid = false
                };
                if(cart == null)
                {
                    Console.WriteLine("Error");
                   return 0;
                }
                
                _db.Orders.Add(cart);
                _db.SaveChanges();
            }                
            return cart.Id; 

        }
        
        public bool ShippingInfo(ShippingInfoInputModel shipping, string user, int cartId)
        {
             if(cartId == 0)
             {
                return false;
             } 
           var userInfo = (from it in _db.ShippingInfos
                           join ord in _db.Orders on it.OrderId equals ord.Id
                            where it.OrderId == cartId && user == ord.UserId
                            select new ShippingInfo
                            {
                                Id = it.Id,
                                UserId = it.UserId,
                                OrderId = it.OrderId,
                                FullName = it.FullName,
                                Country = it.Country,
                                Zipcode = it.Zipcode,
                                City = it.City,
                                Adress = it.Adress,
                                PhoneNumber = it.PhoneNumber

                            }).FirstOrDefault();
            //Ef order details er þegar til fyrir þessa pöntun
            if(userInfo != null)
            {
                userInfo = new ShippingInfo
                {
                Id = shipping.Id,
                UserId = user,
                OrderId = cartId,
                FullName = shipping.FullName,
                Country = shipping.Country,
                Zipcode = shipping.Zipcode,
                City = shipping.City,
                Adress = shipping.Adress,
                PhoneNumber = shipping.PhoneNumber
                };
                _db.ShippingInfos.Update(userInfo);
            } 
            else{
                userInfo = new ShippingInfo
                {
                    Id = shipping.Id,
                    UserId = user,
                    OrderId = cartId,
                    FullName = shipping.FullName,
                    Country = shipping.Country,
                    Zipcode = shipping.Zipcode,
                    City = shipping.City,
                    Adress = shipping.Adress,
                    PhoneNumber = shipping.PhoneNumber
                };
                if(userInfo == null)
                {
                    return false;
                }
                _db.ShippingInfos.Add(userInfo);    
            }
            _db.SaveChanges();
                return true;
        }
        public bool Buy(string userId, int cartId)
        {
            var userInfo = (from or in _db.Orders
                            where cartId == or.OrderId && userId == or.UserId
                     select new Order
                            {
                                Id = or.Id,
                                UserId = or.UserId,
                                Paid = or.Paid
                            }).FirstOrDefault();
            //ef þessi klasi er ekki til
            if(userInfo == null)
            {
                return false;
            }
            userInfo.Paid = true;
            _db.Orders.Update(userInfo);
            return true;
        }
    }
}