using System;
using System.Collections.Generic;
using ListPagination.Core.Domain.Entities;

namespace ListPagination.Presentation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customerList = GetCustomers();

            // TODO: Iniciar a paginação aqui
        }

        private static List<Customer> GetCustomers()
        {
            var customer = new List<Customer>();

            for (int i = 0; i < 35; i++)
                customer.Add(
                    new Customer($"FirstName {i}", $"LastName {i}", $"{i}@email.com")
                );
            
            return customer;
        }
    }
}