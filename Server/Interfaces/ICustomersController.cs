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
        public Task<IEnumerable<Customer>> Get();

        // Get
        // {id}
        public Task<Customer> Get(int id);

        // Post
        public Task<bool> Post(Customer newCustomer);

        // Put
        public Task<bool> Put(Customer newCustomer);
    }
}
