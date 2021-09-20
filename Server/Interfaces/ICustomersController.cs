using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface ICustomersController
    {
        // Get
        public IEnumerable<Customer> Get();

        // Get
        // {id}
        public Customer Get(int id);

        // Post
        public bool Post(Customer newCustomer);

        // Put
        public bool Put(Customer newCustomer);
    }
}
