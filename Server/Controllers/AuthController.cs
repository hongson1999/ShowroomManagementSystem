using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase, IAuthController
    {
        private readonly ShowroomDbContext _context;

        public AuthController(ShowroomDbContext context)
        {
            _context = context;
        }

        private class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public bool CheckValid(string token)
        {
            throw new NotImplementedException();
        }

        public string Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        [HttpPost]


        private bool DealerExists(int id)
        {
            return _context.Dealer.Any(e => e.Id == id);
        }
    }
}
