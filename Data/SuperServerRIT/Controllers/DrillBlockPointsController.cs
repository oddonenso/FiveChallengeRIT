using Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperServerRIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockPointsController : ControllerBase
    {
        private readonly Connection _context;

        public DrillBlockPointsController(Connection context)
        {
            _context = context;
        }

        // GET: api/DrillBlockPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrillBlockPoint>>> GetDrillBlockPoints()
        {
            return await _context.DrillBlockPoint.ToListAsync();
        }

        // GET: api/DrillBlockPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrillBlockPoint>> GetDrillBlockPoint(int id)
        {
            var drillBlockPoint = await _context.DrillBlockPoint.FindAsync(id);

            if (drillBlockPoint == null)
            {
                return NotFound();
            }

            return drillBlockPoint;
        }

        // POST: api/DrillBlockPoints
        [HttpPost]
        public async Task<ActionResult<DrillBlockPoint>> PostDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            _context.DrillBlockPoint.Add(drillBlockPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrillBlockPoint", new { id = drillBlockPoint.Id }, drillBlockPoint);
        }

        // PUT: api/DrillBlockPoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrillBlockPoint(int id, DrillBlockPoint drillBlockPoint)
        {
            if (id != drillBlockPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(drillBlockPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrillBlockPointExists(id))
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

        // DELETE: api/DrillBlockPoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrillBlockPoint(int id)
        {
            var drillBlockPoint = await _context.DrillBlockPoint.FindAsync(id);
            if (drillBlockPoint == null)
            {
                return NotFound();
            }

            _context.DrillBlockPoint.Remove(drillBlockPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrillBlockPointExists(int id)
        {
            return _context.DrillBlockPoint.Any(e => e.Id == id);
        }
    }
}
