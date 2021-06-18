using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UodatedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerAddress PrimaryAddress { get; set; }
    }
}
