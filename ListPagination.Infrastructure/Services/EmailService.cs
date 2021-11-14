using System.Collections.Generic;
using ListPagination.Application.Interfaces;
using ListPagination.Domain.Entities;

namespace ListPagination.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(List<Customer> customers)
        {
        }
    }
}