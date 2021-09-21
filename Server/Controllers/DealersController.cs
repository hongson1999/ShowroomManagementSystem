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
using Server.Extensions;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DealersController : ControllerBase, IDealersController
    {
        private readonly ShowroomDbContext _context;

        public DealersController(ShowroomDbContext context)
        {
            _context = context;
        }

        // GET: api/Dealers
        [HttpGet]
        public async Task<IEnumerable<Dealer>> Get()
        {
            return await _context.Dealers.ToListAsync();
        }

        // GET: api/Dealers/5
        [HttpGet("{id}")]
        public async Task<Dealer> Get(int id)
        {
            var dealer = await _context.Dealers
                .Include(d => d.Order)
                .FirstOrDefaultAsync(d => d.Id == id);

            return dealer;
        }

        // PUT: api/Dealers/5
        [HttpPut]
        public async Task<bool> Put(Dealer dealer)
        {
            if (dealer.Id != dealer.Id)
            {
                return false;
            }

            _context.Entry(dealer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealerExists(dealer.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        // POST: api/Dealers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<bool> Post(Dealer dealer)
        {
            dealer.Password = dealer.Password.HashPasswordMD5();
            _context.Dealers.Add(dealer);
            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE: api/Dealers/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var dealer = await _context.Dealers.FindAsync(id);
            if (dealer == null)
            {
                return false;
            }

            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool DealerExists(int id)
        {
            return _context.Dealers.Any(e => e.Id == id);
        }
    }
}
