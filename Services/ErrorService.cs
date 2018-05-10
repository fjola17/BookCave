using BookCave.Models.InputModels;
using BookCave.Services;
using System;


namespace BookCave.Services
{
    public class ErrorService
    {
        public void ProcessOrder()
        {
            throw new NullReferenceException();
        }
        public void Bla()
        {
            throw new ArgumentNullException();
        }
    }
}