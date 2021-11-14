using System.Collections.Generic;
using ListPagination.Domain.Entities;

namespace ListPagination.Application.Interfaces
{
    public interface IEmailService
    {
         void SendEmail(List<Customer> customers);
    }
}