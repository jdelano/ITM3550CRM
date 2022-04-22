using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.Json;
using HTTPRoutingDemo.Database.Models;

namespace HTTPRoutingDemo.Repositories
{
    public class CustomerRepository
    {
        private readonly CRMContext _context;

        public CustomerRepository(CRMContext context)
        {
            _context = context;
            LoadCustomersDB();
        }

        private void LoadCustomersDB()
        {
            if (_context.Customers.Count() == 0)
            {
                var customer1 = new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe", Balance = 500.00 };
                var customer2 = new Customer { CustomerId = 2, FirstName = "Jim", LastName = "Jones", Balance = 250.00 };
                _context.Customers.Add(customer1);
                _context.Customers.Add(customer2);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public Customer FindCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var dbCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Balance = customer.Balance;
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = FindCustomer(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}

