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
        public IEnumerable<ShowroomVehicle> Get();

        // Get
        // {id}
        public ShowroomVehicle Get(string id);

        // Post
        public bool Post(ShowroomVehicle newVehicle);

        // Put
        public bool Put(ShowroomVehicle newVehicle);

        // Delete
        public bool Delete(string id);
    }
}
