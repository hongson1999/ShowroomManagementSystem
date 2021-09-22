using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase, IOrdersController
    {
        private readonly ShowroomDbContext _context;

        public OrdersController(ShowroomDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        [HttpPost]
        public async Task<bool> Post(Order newOrder)
        {
            try
            {
                await _context.Orders.AddAsync(newOrder);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut]
        public async Task<bool> Put(UpdateStatusOrderModel input)
        {
            try
            {
                Order order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == input.orderId);

                order.StatusId = input.statusId;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
