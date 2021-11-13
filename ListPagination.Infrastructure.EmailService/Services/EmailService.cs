using System.Collections.Generic;
using ListPagination.Core.Application.Interfaces;
using ListPagination.Core.Domain.Entities;

namespace ListPagination.Infrastructure.EmailService.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(List<Customer> customers)
        {
        }
    }
}