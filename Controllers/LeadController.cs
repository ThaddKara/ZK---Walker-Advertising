using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZK___Walker_Advertising.Data;
using ZK___Walker_Advertising.Data.Models;

namespace ZK___Walker_Advertising.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly LeadContext _context;

        public LeadController(LeadContext context)
        {
            _context = context;
        }

        // GET: api/Lead
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadModel>>> GetLeads()
        {
            return await _context.Leads.ToListAsync();
        }

        // GET: api/Lead/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeadModel>> GetLeadModel(Guid id)
        {
            var leadModel = await _context.Leads.FindAsync(id);

            if (leadModel == null)
            {
                return NotFound();
            }

            return leadModel;
        }

        // PUT: api/Lead/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeadModel(Guid id, LeadModel leadModel)
        {
            if (id != leadModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(leadModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadModelExists(id))
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

        // POST: api/Lead
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeadModel>> PostLeadModel(LeadModel leadModel)
        {
            _context.Leads.Add(leadModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeadModel", new { id = leadModel.Id }, leadModel);
        }

        // DELETE: api/Lead/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadModel(Guid id)
        {
            var leadModel = await _context.Leads.FindAsync(id);
            if (leadModel == null)
            {
                return NotFound();
            }

            _context.Leads.Remove(leadModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeadModelExists(Guid id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
