using System.Collections.Generic;
using ListPagination.Core.Application.Interfaces;
using ListPagination.Core.Domain.Entities;
using ListPagination.Infrastructure.EmailService.Services;

namespace ListPagination.Presentation.ConsoleApp
{
    class Program
    {
        private static List<Customer> _customerList;
        private static IEmailService _emailService;

        static void Main(string[] args)
        {
            _emailService = new EmailService();
            _customerList = GetCustomers();

            // Solution One
            RunSolutionOne();

            // Solution Two
            RunSolutionTwo();
        }

        private static void RunSolutionOne()
        {

        }

        private static void RunSolutionTwo()
        {

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