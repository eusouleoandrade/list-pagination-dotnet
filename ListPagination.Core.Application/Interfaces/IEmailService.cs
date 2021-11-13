using System.Collections.Generic;
using ListPagination.Core.Domain.Entities;

namespace ListPagination.Core.Application.Interfaces
{
    public interface IEmailService
    {
         void SendEmail(List<Customer> customers);
    }
}