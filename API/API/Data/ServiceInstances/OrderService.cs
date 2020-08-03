using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Data.ServiceInstances
{
    public class OrderService : IOrderService
    {

        private readonly Context context;
        private readonly DbSet<Order> orders;
        private readonly DbSet<Consumable> consumables;
        private readonly DbSet<Passenger> passengers;

        public OrderService(Context context)
        {
            this.context = context;
            orders = context.Orders;
            consumables = context.Consumables;
            passengers = context.Passengers;
        }

        public bool FinishOrder(int id)
        {
            var order = orders.SingleOrDefault(s => s.OrderId == id) ?? throw new ArgumentException();
            var ret = order.Finish();
            context.SaveChanges();
            return ret;
        }

        public ICollection<Order> GetAll()
        {
            return orders
                .Include(o => o.OrderLines).ThenInclude(ol => ol.Consumable)
                .Include(o => o.Passenger)
                .AsNoTracking().ToList();
        }

        public ICollection<Order> GetByUser(int passengerId)
        {
            return orders
                .Where(o => o.Passenger.PassengerId == passengerId)
                .Include(o => o.OrderLines).ThenInclude(ol => ol.Consumable)
                .Include(o => o.Passenger)
                .AsNoTracking().ToList();
        }

        public int PlaceOrder(Order order)
        {

            SetupNewOrder(order);
            orders.Add(order);
            context.SaveChanges();
            return order.OrderId;
        }

        public void SetupNewOrder(Order order)
        {
            AddConsumablesToOrderLines(order);
            SetPassenger(order);
        }

        public void AddConsumablesToOrderLines(Order order)
        {
            order.OrderLines.ForEach(ol => ol.Consumable = FindConsumable(ol.ConsumableId));
        }

        public void SetPassenger(Order order)
        {
            order.Passenger = FindPassenger(order.PassengerId);
        }

        public Consumable FindConsumable(int id)
        {
            return consumables.FirstOrDefault(c => c.ConsumableId == id);
        }

        public Passenger FindPassenger(int id)
        {
            return passengers.FirstOrDefault(p => p.PassengerId == id);
        }

    }
}
