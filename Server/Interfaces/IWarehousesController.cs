using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IWarehousesController
    {
        // Get
        public Task<IEnumerable<WarehouseVehicle>> Get(string showRoomVehicleId);
    }
}
