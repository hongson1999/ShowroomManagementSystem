using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IServicesController
    {
        // Get
        public IEnumerable<Service> Get();
    }
}
