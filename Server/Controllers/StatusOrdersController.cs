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
    [Route("[controller]")]
    [ApiController]
    public class StatusOrdersController : ControllerBase, IStatusOrdersController
    {
        private readonly ShowroomDbContext _context;

        public StatusOrdersController(ShowroomDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<StatusOrder>> Get()
        {
            return await _context.StatusOrders.ToListAsync();
        }
    }
}
