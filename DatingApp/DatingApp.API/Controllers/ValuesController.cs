﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return Ok(value);
        }

        // POSTs api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUTs api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETEs api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}