using API.Data.IServices;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.ServiceInstances
{
    public class OrderService : IOrderService
    {
        public bool FinishOrder(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetByUser(int passengerId)
        {
            throw new NotImplementedException();
        }

        public int PlaceOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
