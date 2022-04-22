using System;
using System.Collections.Generic;
using HTTPRoutingDemo.Database.Models;
using HTTPRoutingDemo.Repositories;

namespace HTTPRoutingDemo.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.FindCustomer(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }
    }
}

