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
        public Task<IEnumerable<Dealer>> Get();

        // {id}
        public Task<Dealer> Get(int id);

        // Post
        public Task<bool> Post(Dealer newDealer);

        // Put
        public Task<bool> Put(Dealer newDealer);
    }
}
