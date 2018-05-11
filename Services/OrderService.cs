using BookCave.Models.InputModels;
using BookCave.Services;
using System;

namespace BookCave.Services
{
    public class OrderService : ErrorService
    {
        public void Shipping(ShippingInfoInputModel shipping)
        {
            if(string.IsNullOrEmpty(shipping.FullName))
            {
                throw new Exception("You need to put your name here");
            }
            else if(String.IsNullOrEmpty(shipping.Country))
            {
                throw new Exception("Please select a country");
            }
            else if(String.IsNullOrEmpty(shipping.Zipcode))
            {
                throw new Exception("You need enter your zipcode");
            }
            else if(string.IsNullOrEmpty(shipping.City))
            {
                throw new Exception("You need enter your city");
            }
            else if(string.IsNullOrEmpty(shipping.Adress))
            {
                throw new Exception("You need to enter your adress");
            }
            else if(string.IsNullOrEmpty(shipping.PhoneNumber))
            {
                throw new Exception("Please enter a valid phone number");
            }
            //else if()

        }
        public void BillingInfo(BillingInputModel billing)
        {
            if(string.IsNullOrEmpty(billing.PaymentMethod))
            {
                throw new Exception("Please enter a payment method");
            }
            else if(string.IsNullOrEmpty(billing.CardNumber))
            {
                throw new Exception("Please enter a valid cardnumber");
            }

        }

        public void DeleteById(int? bookId, string user)
        {
            if(string.IsNullOrEmpty(bookId.ToString()))
            {
                throw new Exception("Book not found");
            }

        }
       /* public OrderDetailsViewModel Cart(string userid)
        {
            
           // var cart = _orderrepo.Cart(userid, cartId)
        }*/
        public void AddToCart(int id, string userid)
        {

        }
        public void Buy(string userid)
        {

        }
    }
}