using System;
using System.Collections.Generic;
using System.Configuration;
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
        private static int _recordPerPage;

        static void Main(string[] args)
        {
            _emailService = new EmailService();
            _customerList = GeneratesCustomers(19);
            _recordPerPage = Convert.ToInt32(ConfigurationManager.AppSettings.Get("configRecordPerPage"));

            // Solution One
            // RunSolutionOne();

            // Solution Two
            // RunSolutionTwo();

            // Solution Three
            RunSolutiomThree();
        }

        private static void RunSolutionOne()
        {
            decimal numberOfPages = Math.Ceiling((decimal)_customerList.Count / (decimal)_recordPerPage);

            for (int currentPage = 0; currentPage < numberOfPages; currentPage++)
            {
                var customers = _customerList.Skip(_recordPerPage * currentPage).Take(_recordPerPage).ToList();

                if (!customers.Any())
                    break;

                _emailService.SendEmail(customers);
            }
        }

        private static void RunSolutionTwo()
        {
            decimal numberOfPages = Math.Ceiling((decimal)_customerList.Count / (decimal)_recordPerPage);
            int currentIndex = 0;
            int currentPage = 1;

            do
            {
                var customers = _customerList.Skip(_recordPerPage * currentIndex).Take(_recordPerPage).ToList();

                if (!customers.Any())
                    break;

                _emailService.SendEmail(customers);

                currentIndex++;
                currentPage++;

            } while (currentPage <= numberOfPages);
        }

        private static void RunSolutiomThree()
        {
            decimal numberOfPages = Math.Ceiling((decimal)_customerList.Count / (decimal)_recordPerPage);
            int currentIndex = 0;
            int currentPage = 1;

            while (currentPage <= numberOfPages)
            {
                var customers = _customerList.Skip(_recordPerPage * currentIndex).Take(_recordPerPage).ToList();

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