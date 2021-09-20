using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    interface IAuthController
    {
        // Post
        public string Login(string userName, string password);

        public bool CheckValid(string token);
    }
}
