using System;
using System.Collections.Generic;
using System.Linq;
using ListPagination.Application.Interfaces;
using ListPagination.Domain.Entities;
using ListPagination.Infrastructure.Services;

namespace ListPagination.Presentation
{
    class Program
    {
        private static List<Customer> _customerList;
        private static IEmailService _emailService;

        static void Main(string[] args)
        {
            _emailService = new EmailService();
            _customerList = GeneratesCustomers(19);

            // Solution One
            // RunSolutionOne();

            // Solution Two
            // RunSolutionTwo();

            // Solution Three
            RunSolutiomThree();
        }

        private static void RunSolutionOne()
        {
            int recordPerPage = 20;
            int countCustomers = _customerList.Count;
            decimal numberOfPages = Math.Ceiling((decimal)_customerList.Count / (decimal)recordPerPage);

            for (int currentPage = 0; currentPage < numberOfPages; currentPage++)
            {
                var customers = _customerList.Skip(recordPerPage * currentPage).Take(recordPerPage).ToList();

                if (!customers.Any())
                    break;

                _emailService.SendEmail(customers);
            }
        }

        private static void RunSolutionTwo()
        {
            int recordPerPage = 5;
            int countCustomers = _customerList.Count;
            decimal numberOfPages = Math.Ceiling((decimal)_customerList.Count / (decimal)recordPerPage);
            int currentIndex = 0;
            int currentPage = 1;

            do
            {
                var customers = _customerList.Skip(recordPerPage * currentIndex).Take(recordPerPage).ToList();

                if (!customers.Any())
                    break;

                _emailService.SendEmail(customers);

                currentIndex++;
                currentPage++;

            } while (currentPage <= numberOfPages);
        }

        private static void RunSolutiomThree()
        {
            int recordPerPage = 5;
            int countCustomers = _customerList.Count;
            decimal numberOfPages = Math.Ceiling((decimal)_customerList.Count / (decimal)recordPerPage);
            int currentIndex = 0;
            int currentPage = 1;

            while (currentPage <= numberOfPages)
            {
                var customers = _customerList.Skip(recordPerPage * currentIndex).Take(recordPerPage).ToList();

                if (!customers.Any())
                    break;

                _emailService.SendEmail(customers);

                currentIndex++;
                currentPage++;
            }
        }

        private static List<Customer> GeneratesCustomers(int amount)
        {
            var customer = new List<Customer>();

            for (int i = 1; i <= amount; i++)
                customer.Add(
                    new Customer($"FirstName {i}", $"LastName {i}", $"{i}@email.com")
                );

            return customer;
        }
    }
}