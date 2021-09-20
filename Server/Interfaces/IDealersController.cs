using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IDealersController
    {
        // Get
        public IEnumerable<Dealer> Get();

        // {id}
        public Dealer Get(int id);

        // Post
        public bool Post(Dealer newDealer);

        // Put
        public bool Put(Dealer newDealer);
    }
}
