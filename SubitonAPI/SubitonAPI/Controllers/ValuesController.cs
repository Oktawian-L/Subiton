﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubitonAPI.Data;
using SubitonAPI.Models;

namespace SubitonAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Values
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Values>>> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET: api/Values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Values>> GetValues(int id)
        {
            var values = await _context.Values.FindAsync(id);

            if (values == null)
            {
                return NotFound();
            }

            return values;
        }

        // PUT: api/Values/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValues(int id, Values values)
        {
            if (id != values.Id)
            {
                return BadRequest();
            }

            _context.Entry(values).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValuesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Values
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Values>> PostValues(Values values)
        {
            _context.Values.Add(values);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValues", new { id = values.Id }, values);
        }

        // DELETE: api/Values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Values>> DeleteValues(int id)
        {
            var values = await _context.Values.FindAsync(id);
            if (values == null)
            {
                return NoContent();
            }

            if (values == null)
            {
                return NotFound();
            }

            _context.Values.Remove(values);
            await _context.SaveChangesAsync();

            return values;
        }

        private bool ValuesExists(int id)
        {
            return _context.Values.Any(e => e.Id == id);
        }
    }
}
