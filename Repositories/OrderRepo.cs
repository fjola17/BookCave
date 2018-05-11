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
            //Finnur allar
            var ordersFromOwner = (from ord in _db.Orders
                                   where userId == ord.UserId && ord.Paid == true
                                   orderby ord.OrderId descending
                                   select new OrderViewModel
                                   {
                                      
                                      TotalPrice = ord.TotalPrice
                                    }).ToList();
            return ordersFromOwner;
        }
         
         public OrderDetailsViewModel GetById(int? id, string userId)
        {
            //finnur ákvena pöntun og skilar upplýsingum um hana
            var aOrder = (from ord in _db.Orders
                        where ord.OrderId == id && ord.Paid == true && ord.UserId == userId
                       select new OrderDetailsViewModel() //Hér eiga allar bækurnar að koma upp
                        {
                            Paid = ord.Paid,
                            TotalPrice = ord.TotalPrice
                        }).FirstOrDefault();
            //finnur allar bækurnar í pöntunninni
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
                return aOrder;
            }
            aOrder.BooksInOrder = booksInorder;
            
            return aOrder;
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
                               select bks).FirstOrDefault();
            
            if(bookTodelete != null)
            {
                _db.BooksInCarts.Remove(bookTodelete);     
                _db.SaveChanges();
                return false;
            }
            return true;
        }

        public OrderDetailsViewModel Cart(string userId, int cartId)
        {
            //finn körfunna og byrti vörurnar inn í þeim
            var cart = (from ca in _db.Orders
                        where ca.Id == cartId && userId == ca.UserId
                        select new OrderDetailsViewModel
                        {
                            Id = ca.Id,
                            Paid = ca.Paid,
                            TotalPrice = ca.TotalPrice
                        }).FirstOrDefault();
            //bækurnar í körfunni
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
                        Price = bks.Price,
                        Quantity = bksc.Quantity
                    }).ToList();
            //ef ekkert er í körfunni
            if(cart == null)
            {
                return cart;
            }
            cart.BooksInOrder = booksInCart;
            foreach(var books in booksInCart)
            {
                cart.TotalPrice += books.Price * books.Quantity;
            }

            return cart;

        }
        public bool AddToCart(int id, string userId, int cartId)
        {  
            var itemincart = (from it in _db.BooksInCarts            
                            where it.UserId == userId && id == it.BookId && cartId == it.OrderId
            select new BooksInCart
            {
                Id = it.Id,
                BookId = id,
                Quantity = it.Quantity,
                OrderId = it.Id,
                UserId =it.UserId,

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
            //cartId.TotalPrice += itemincart.Price;
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
                //ef karfan finnst ekki
                if(cart == null)
                {
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
            
            var userInfo = new ShippingInfo
            {
                UserId = user,
                OrderId = cartId,
                FullName = shipping.FullName,
                Country = shipping.Country,
                Zipcode = shipping.Zipcode,
                City = shipping.City,
                Adress = shipping.Adress,
                PhoneNumber = shipping.PhoneNumber
            };
            //ef næst ekki í notanda
            if(userInfo == null)
            {
                return false;
            }
            _db.ShippingInfos.Add(userInfo);
            
            _db.SaveChanges();
                return true;
            }
        
        public bool BillingInfo(BillingInputModel info, string userId, int cartId)
        {
            if(userId == null)
            {
                return false;
            }
            
            var userInfo = new BillingInfo
            {
                UserId = userId,
                Name = info.Name,
                Country = info.Country,
                Zipcode = info.Zipcode,
                City = info.City,
                Adress = info.Address,
                OrderId = cartId,
                PaymentMethod = info.PaymentMethod,
                CardNumber = info.CardNumber

            };
            if(userInfo == null)
            {
                return false;
            }
            _db.BillingInfos.Add(userInfo);
            _db.SaveChanges();
            return true;
        }
        public ProcessOrderViewModel ViewOrder(int cartId, string userId)
        {
            var order = (from ord in _db.Orders
            join shi in _db.ShippingInfos on ord.Id equals shi.OrderId
            join bil in _db.BillingInfos on shi.OrderId equals bil.OrderId
                        where ord.Id == cartId && ord.UserId == userId
                        select new ProcessOrderViewModel
                        {
                            OrderId = ord.Id,                           
                            FullName = shi.FullName,
                            Country = shi.Country,
                            Zipcode = shi.Zipcode,
                            City = shi.City,
                            Adress = shi.Adress,
                            PhoneNumber = shi.PhoneNumber,
                            BillingName = bil.Name,
                            BillingCountry = bil.Country,
                            BillingCity = bil.City,
                            BillingAdress = bil.Adress,
                            Zip = bil.Zipcode,
                            PaymentMethod = bil.PaymentMethod,
                            TotalPrice = ord.TotalPrice
                        }).FirstOrDefault();
                var books = (from bks in _db.Books
                join bksc in _db.BooksInCarts on bks.Id equals bksc.BookId
                    join ord in _db.Orders on bksc.OrderId equals ord.Id
                    where ord.Id == cartId && userId == ord.UserId
                    select new BookCartViewModel
                    {
                        Id = bksc.Id,
                        Title = bks.Title,
                        BookId = bks.Id,
                        CoverImage = bks.CoverImage,                        
                        Price = bks.Price,
                        Quantity = bksc.Quantity
                    }).ToList();
            if(order == null)
            {
                return order;
            }
            order.Books = books;
            foreach(var book in books)
            {
                order.TotalPrice += book.Price * book.Quantity;
            }
            return order;
        }

        public bool Buy(string userId, int cartId)
        {
            var userInfo = (from or in _db.Orders
                            where userId == or.UserId && or.Paid == false
                            select or).FirstOrDefault();
            //ef ekkert er til staðar
            if(userInfo == null)
            {
                return false;
            }
            //Status á paid breytist yfir í true
            userInfo.Paid = true;
            _db.Orders.Update(userInfo);
            return true;
        }
    }
}