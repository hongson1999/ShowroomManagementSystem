using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IOrdersController
    {
        // Get
        public IEnumerable<Order> Get();

        // Get
        // {id}
        public Order Get(int id);

        // Post
        public bool Post(Order newOrder);

        // Put
        public bool Put(int orderId, StatusOrder newStatus);
    }
}
