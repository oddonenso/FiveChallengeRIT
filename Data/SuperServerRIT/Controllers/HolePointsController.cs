using Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperServerRIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolePointsController : ControllerBase
    {
        private readonly Connection _context;

        public HolePointsController(Connection context)
        {
            _context = context;
        }

        // GET: api/HolePoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolePoint>>> GetHolePoints()
        {
            return await _context.HolePoint.ToListAsync();
        }

        // GET: api/HolePoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolePoint>> GetHolePoint(int id)
        {
            var holePoint = await _context.HolePoint.FindAsync(id);

            if (holePoint == null)
            {
                return NotFound();
            }

            return holePoint;
        }

        // POST: api/HolePoints
        [HttpPost]
        public async Task<ActionResult<HolePoint>> PostHolePoint(HolePoint holePoint)
        {
            _context.HolePoint.Add(holePoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHolePoint", new { id = holePoint.Id }, holePoint);
        }

        // PUT: api/HolePoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolePoint(int id, HolePoint holePoint)
        {
            if (id != holePoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(holePoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolePointExists(id))
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

        // DELETE: api/HolePoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolePoint(int id)
        {
            var holePoint = await _context.HolePoint.FindAsync(id);
            if (holePoint == null)
            {
                return NotFound();
            }

            _context.HolePoint.Remove(holePoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HolePointExists(int id)
        {
            return _context.HolePoint.Any(e => e.Id == id);
        }
    }
}
