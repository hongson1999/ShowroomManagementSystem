using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IWarehousesController
    {
        // Get
        public IEnumerable<IWarehousesController> Get(string showRoomVehicleId);
    }
}
