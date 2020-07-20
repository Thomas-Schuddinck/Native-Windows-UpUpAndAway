using API.Data.IServices;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace API.Data.ServiceInstances
{
    public class OrderService : IOrderService
    {

        private readonly Context context;
        private readonly DbSet<Order> orders;

        public OrderService(Context context)
        {
            this.context = context;
            orders = context.Orders;
        }

        public bool FinishOrder(int id)
        {
            var order = orders.SingleOrDefault(s => s.OrderId == id) ?? throw new ArgumentException();

            return order.Finish();
        }

        public ICollection<Order> GetAll()
        {
            return orders.AsNoTracking().ToList();
        }

        public ICollection<Order> GetByUser(int passengerId)
        {
            return orders.AsNoTracking().Where(s => s.PassengerId == passengerId).ToList();
        }

        public int PlaceOrder(Order order)
        {
            orders.Add(order);
            context.SaveChanges();
            return order.OrderId;
        }
    }
}
