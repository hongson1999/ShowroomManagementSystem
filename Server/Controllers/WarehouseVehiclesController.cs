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
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseVehiclesController : ControllerBase, IWarehousesController
    {
        private readonly ShowroomDbContext _context;

        public WarehouseVehiclesController(ShowroomDbContext context)
        {
            _context = context;
        }

        [HttpGet("{showRoomVehicleId}")]
        public async Task<IEnumerable<WarehouseVehicle>> Get(string showRoomVehicleId)
        {
            var showroomVehicleModel = await _context.WarehouseVehicles
                .Where(wv => wv.ShowroomVehicleId.Equals(showRoomVehicleId))
                .ToListAsync();

            return showroomVehicleModel;
        }
    }
}
