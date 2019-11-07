using System;
using System.Collections.Generic;
using System.Text;

namespace Alligator.Domain.Model
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
