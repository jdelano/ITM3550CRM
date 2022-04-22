using System;
using System.Collections.Generic;
using HTTPRoutingDemo.Database.Models;
using HTTPRoutingDemo.Repositories;

namespace HTTPRoutingDemo.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrder(int id)
        {
            return _orderRepository.FindOrder(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }
    }
}

