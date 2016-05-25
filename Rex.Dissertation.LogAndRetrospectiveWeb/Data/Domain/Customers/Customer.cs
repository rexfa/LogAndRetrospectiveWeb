using System;
using System.Collections.Generic;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain;

namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers
{
    public class Customer : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; } 
    }
}
