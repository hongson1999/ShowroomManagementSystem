using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IStatusOrdersController
    {
        // Get
        public IEnumerable<StatusOrder> Get();
    }
}
