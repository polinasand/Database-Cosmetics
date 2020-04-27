using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseCosmetics.Models;

namespace DatabaseCosmetics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosmTypesController : ControllerBase
    {
        private readonly DatabaseCosmeticsContext _context;

        public CosmTypesController(DatabaseCosmeticsContext context)
        {
            _context = context;
        }

        // GET: api/CosmTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CosmType>>> GetCosmTypes()
        {
            return await _context.CosmTypes.ToListAsync();
        }

        // GET: api/CosmTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CosmType>> GetCosmType(int id)
        {
            var cosmType = await _context.CosmTypes.FindAsync(id);

            if (cosmType == null)
            {
                return NotFound();
            }

            return cosmType;
        }

        // PUT: api/CosmTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCosmType(int id, CosmType cosmType)
        {
            if (id != cosmType.Id)
            {
                return BadRequest();
            }

            _context.Entry(cosmType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CosmTypeExists(id))
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

        // POST: api/CosmTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CosmType>> PostCosmType(CosmType cosmType)
        {
            _context.CosmTypes.Add(cosmType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCosmType", new { id = cosmType.Id }, cosmType);
        }

        // DELETE: api/CosmTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CosmType>> DeleteCosmType(int id)
        {
            var cosmType = await _context.CosmTypes.FindAsync(id);
            if (cosmType == null)
            {
                return NotFound();
            }

            _context.CosmTypes.Remove(cosmType);
            await _context.SaveChangesAsync();

            return cosmType;
        }

        private bool CosmTypeExists(int id)
        {
            return _context.CosmTypes.Any(e => e.Id == id);
        }
    }
}
