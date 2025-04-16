using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HTTPRoutingDemo.Database.Models;
using HTTPRoutingDemo.Repositories;

namespace HTTPRoutingDemo.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<Order?> GetOrderAsync(int orderId);
        IEnumerable<Order> GetOrders();
        Task<bool> UpdateOrderAsync(Order order);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order?> GetOrderAsync(int orderId)
        {
            return await _orderRepository.FindOrderAsync(orderId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.CreateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
        }
    }
}

