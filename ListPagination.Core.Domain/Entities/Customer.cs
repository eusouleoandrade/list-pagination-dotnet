using System;

namespace ListPagination.Core.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Customer(Guid id, string firstName, string lastName, string email)
        {
            Id = Id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Customer(string firstName, string lastName, string email) 
            :this(Guid.NewGuid(), firstName, lastName, email)
        {
        }
    }
}