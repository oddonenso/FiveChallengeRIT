using Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperServerRIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolesController : ControllerBase
    {
        private readonly Connection _context;

        public HolesController(Connection context)
        {
            _context = context;
        }

        // GET: api/Holes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hole>>> GetHoles()
        {
            return await _context.Hole.ToListAsync();
        }

        // GET: api/Holes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hole>> GetHole(int id)
        {
            var hole = await _context.Hole.FindAsync(id);

            if (hole == null)
            {
                return NotFound();
            }

            return hole;
        }

        // POST: api/Holes
        [HttpPost]
        public async Task<ActionResult<Hole>> PostHole(Hole hole)
        {
            _context.Hole.Add(hole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHole", new { id = hole.Id }, hole);
        }

        // PUT: api/Holes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHole(int id, Hole hole)
        {
            if (id != hole.Id)
            {
                return BadRequest();
            }

            _context.Entry(hole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoleExists(id))
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

        // DELETE: api/Holes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHole(int id)
        {
            var hole = await _context.Hole.FindAsync(id);
            if (hole == null)
            {
                return NotFound();
            }

            _context.Hole.Remove(hole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoleExists(int id)
        {
            return _context.Hole.Any(e => e.Id == id);
        }
    }
}
