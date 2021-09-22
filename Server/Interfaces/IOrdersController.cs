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
        public Task<IEnumerable<Order>> Get();

        // Get
        // {id}
        public Task<Order> Get(int id);

        // Post
        public Task<bool> Post(Order newOrder);

        // Put
        public Task<bool> Put(int orderId, StatusOrder newStatus);
    }

    public class UpdateStatusOrderModel
    {
        public int orderId { get; set; }
        public int statusId { get; set; }
    }
}
