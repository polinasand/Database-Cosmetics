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
    public class FinishesController : ControllerBase
    {
        private readonly DatabaseCosmeticsContext _context;

        public FinishesController(DatabaseCosmeticsContext context)
        {
            _context = context;
        }

        // GET: api/Finishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Finish>>> GetFinishes()
        {
            return await _context.Finishes.ToListAsync();
        }

        // GET: api/Finishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Finish>> GetFinish(int id)
        {
            var finish = await _context.Finishes.FindAsync(id);

            if (finish == null)
            {
                return NotFound();
            }

            return finish;
        }

        // PUT: api/Finishes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinish(int id, Finish finish)
        {
            if (id != finish.Id)
            {
                return BadRequest();
            }

            _context.Entry(finish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishExists(id))
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

        // POST: api/Finishes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Finish>> PostFinish(Finish finish)
        {
            _context.Finishes.Add(finish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinish", new { id = finish.Id }, finish);
        }

        // DELETE: api/Finishes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Finish>> DeleteFinish(int id)
        {
            var finish = await _context.Finishes.FindAsync(id);
            if (finish == null)
            {
                return NotFound();
            }

            _context.Finishes.Remove(finish);
            await _context.SaveChangesAsync();

            return finish;
        }

        private bool FinishExists(int id)
        {
            return _context.Finishes.Any(e => e.Id == id);
        }
    }
}
