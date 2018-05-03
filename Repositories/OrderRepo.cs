using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        public List<Order> GetByOwnerId(int ownerId)
        {
            //Útfæra
        }
        public OrderViewModel GetbyId(int orderId)
        {
            //útfæra
        }
        public bool Create(OrderViewModel ovm)
        {
            return true;
        }
        public bool DeleteById(int orderId)
        {
            return false;
        }
        
        public bool Buy(OrderViewModel owm)
        {
            return true;
        }
    }
}