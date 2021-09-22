using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IVehiclesController
    {
        // Get
        public Task<IEnumerable<Vehicle>> Get();
    }
}
