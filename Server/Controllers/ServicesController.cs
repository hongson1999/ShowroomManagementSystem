﻿using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase, IServicesController
    {
        private readonly ShowroomDbContext _context;

        public ServicesController(ShowroomDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Service>> Get()
        {
            return await _context.Services.ToListAsync();
        }
    }
}
