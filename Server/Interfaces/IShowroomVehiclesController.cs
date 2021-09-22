using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IShowroomVehiclesController
    {
        // Get
        public Task<IEnumerable<ShowroomVehicle>> Get();

        // Get
        // {id}
        public Task<ShowroomVehicle> Get(string id);

        // Post
        public Task<bool> Post(ShowroomVehicle newVehicle);

        // Put
        public Task<bool> Put(ShowroomVehicle newVehicle);

        // Delete
        public Task<bool> Delete(string id);
    }
}
