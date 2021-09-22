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
    public class ShowroomVehiclesController : ControllerBase, IShowroomVehiclesController
    {
        private readonly ShowroomDbContext _context;

        public ShowroomVehiclesController(ShowroomDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ShowroomVehicle>> Get()
        {
            return await _context.ShowroomVehicles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ShowroomVehicle> Get(string id)
        {
            var showroomVehicleModel = await _context.ShowroomVehicles.FindAsync(id);

            return showroomVehicleModel;
        }

        [HttpPost]
        public async Task<bool> Post(ShowroomVehicle newVehicle)
        {
            try
            {
                _context.ShowroomVehicles.Add(newVehicle);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut()]
        public async Task<bool> Put(ShowroomVehicle editVehicle)
        {
            if (editVehicle.Id != editVehicle.Id)
            {
                return false;
            }

            _context.Entry(editVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowroomVehicleExists(editVehicle.Id))
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

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            var showroomVehicleModel = await _context.ShowroomVehicles.FindAsync(id);
            if (showroomVehicleModel == null)
            {
                return false;
            }

            _context.ShowroomVehicles.Remove(showroomVehicleModel);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ShowroomVehicleExists(string id)
        {
            return _context.ShowroomVehicles.Any(v => v.Id.Equals(id));
        }
    }
}
