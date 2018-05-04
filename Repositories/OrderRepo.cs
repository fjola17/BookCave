using System.Collections.Generic;
using BookCave.Data.EntityModels;
using System.Linq;
using System.Diagnostics;
using BookCave.Models.ViewModels;
using BookCave.Data;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private DataContext _db ;

        public OrderRepo() 
        {
            _db = new DataContext();
        }
        public List<OrderViewModel> GetByOwnerId(int ownerId)
        {
            //Ath hvernig á að birta bækur??
            var ordersFromOwner = (from ord in _db.Orders
                                   where ownerId == ord.OwnerId
                                   select new OrderViewModel{
                                      OwnerId = ord.OwnerId,
                                      OrderId = ord.OrderId,
                                      Paid = ord.Paid,
                                      TotalPrice = ord.TotalPrice
                                    }).ToList();
            return ordersFromOwner;
        }
        public OrderViewModel GetById(int orderId)
        {
            var aOrder = (from ord in _db.Orders
                        where ord.OrderId == orderId
                        //líkleg join hér sem á eftir að útfæra
                        select new OrderDetailsViewModel //Hér eiga allar bækurnar að koma upp
                        {
                            OwnerId = ord.OwnerId,
                            OrderId = ord.OrderId,
                            Paid = ord.Paid,
                            TotalPrice = ord.TotalPrice
                        }).SingleOrDefault();
            
            return aOrder;
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