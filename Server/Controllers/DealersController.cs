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
            return await _context.Dealer.ToListAsync();
        }

        public string GetTest()
        {
            string s = "showroom";
            return s.GenerateRandomId(10);
        }

        // GET: api/Dealers/5
        [HttpGet("{id}")]
        public async Task<Dealer> Get(int id)
        {
            var dealer = await _context.Dealer.FindAsync(id);

            return dealer;
        }

        // PUT: api/Dealers/5
        [HttpPut("{id}")]
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
            _context.Dealer.Add(dealer);
            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE: api/Dealers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dealer = await _context.Dealer.FindAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }

            _context.Dealer.Remove(dealer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DealerExists(int id)
        {
            return _context.Dealer.Any(e => e.Id == id);
        }
    }
}
