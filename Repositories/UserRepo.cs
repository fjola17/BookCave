using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class UserRepo
    {
        public bool Create()
        {
            //ToDo
            return true;
        }
        public bool DeleteById(int userId)
        {
            //ToDO
            return false;
        }
        public UserViewModel GetByUserId(int userId)
        {
            var user = new UserViewModel();
            //ToDo
            return user;
        }
    }
}