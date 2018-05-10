using BookCave.Models.InputModels;
using BookCave.Services;
using System;

namespace BookCave.Services
{
    public class OrderService : ErrorService
    {
        public void ProcessOrder(ShippingInfoInputModel shipping)
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
    }
}