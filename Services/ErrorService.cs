using BookCave.Models.InputModels;
using BookCave.Services;
using System;


namespace BookCave.Services
{
    public class ErrorService
    {
        public void Shipping()
        {
            throw new NullReferenceException();
        }
        public void BillingInfo()
        {
            throw new NullReferenceException();
        }
        public void Feedback()
        {
            throw new NullReferenceException();
        }
    }
}