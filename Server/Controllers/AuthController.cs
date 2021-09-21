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
using Server.Extensions;

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

        [HttpGet("Valid")]
        public bool CheckValid(string token)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Login")]
        public ActionResult<string> Login(LoginModel input)
        {
            if (!DealerExists(input.Email, input.Password))
            {
                return Unauthorized();
            }

            return "";
        }

        private bool DealerExists(string email, string password)
        {
            return _context.Dealers.Any(e => e.Email.Equals(email) && e.Password.Equals(password.HashPasswordMD5()));
        }
    }
}
