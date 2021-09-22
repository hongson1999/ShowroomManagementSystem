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
    public class CustomersController : ControllerBase, ICustomersController
    {
        private readonly ShowroomDbContext _context;

        public CustomersController(ShowroomDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        [HttpPost]
        public async Task<bool> Post(Customer newCustomer)
        {
            try
            {
                await _context.Customers.AddAsync(newCustomer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut]
        public async Task<bool> Put(Customer newCustomer)
        {
            try
            {
                _context.Entry(newCustomer).State = EntityState.Modified;
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
