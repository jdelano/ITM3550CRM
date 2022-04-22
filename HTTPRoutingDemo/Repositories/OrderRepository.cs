using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.Json;
using HTTPRoutingDemo.Database.Models;

namespace HTTPRoutingDemo.Repositories
{
    public class OrderRepository
    {
        private readonly CRMContext _context;

        public OrderRepository(CRMContext context)
        {
            _context = context;
            LoadOrdersDB();
        }

        private void LoadOrdersDB()
        {
            if (_context.Orders.Count() == 0)
            {
                var order1 = new Order { OrderId = 1, OrderDate = DateTime.Now, NumberOfItemsInOrder = 2, OrderTotal = 203.43 };
                var order2 = new Order { OrderId = 2, OrderDate = DateTime.Now - TimeSpan.FromDays(90), NumberOfItemsInOrder = 2, OrderTotal = 203.43 };
                _context.Orders.Add(order1);
                _context.Orders.Add(order2);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }

        public Order FindOrder(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            var dbOrder = _context.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            dbOrder.OrderDate = order.OrderDate;
            dbOrder.NumberOfItemsInOrder = order.NumberOfItemsInOrder;
            dbOrder.OrderTotal = order.OrderTotal;
            _context.SaveChanges();
        }


        public void DeleteOrder(int id)
        {
            var order = FindOrder(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}

