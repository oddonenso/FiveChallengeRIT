using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Tables;

namespace DrillBlockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlocksController : ControllerBase
    {
        private readonly Connection _context;

        public DrillBlocksController(Connection context)
        {
            _context = context;
        }

        // GET: api/DrillBlocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrillBlock>>> GetDrillBlocks()
        {
            return await _context.DrillBlock.ToListAsync();
        }

        // GET: api/DrillBlocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrillBlock>> GetDrillBlock(int id)
        {
            var drillBlock = await _context.DrillBlock.FindAsync(id);

            if (drillBlock == null)
            {
                return NotFound();
            }

            return drillBlock;
        }

        // POST: api/DrillBlocks
        [HttpPost]
        public async Task<ActionResult<DrillBlock>> PostDrillBlock([FromBody] DrillBlock drillBlock)
        {
            if (drillBlock == null || string.IsNullOrEmpty(drillBlock.Name))
            {
                return BadRequest("DrillBlock is null or missing required fields.");
            }

            _context.DrillBlock.Add(drillBlock);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDrillBlock), new { id = drillBlock.Id }, drillBlock);
        }

        // PUT: api/DrillBlocks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrillBlock(int id, DrillBlock drillBlock)
        {
            if (id != drillBlock.Id)
            {
                return BadRequest();
            }

            _context.Entry(drillBlock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrillBlockExists(id))
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

        // DELETE: api/DrillBlocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrillBlock(int id)
        {
            var drillBlock = await _context.DrillBlock.FindAsync(id);
            if (drillBlock == null)
            {
                return NotFound();
            }

            _context.DrillBlock.Remove(drillBlock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrillBlockExists(int id)
        {
            return _context.DrillBlock.Any(e => e.Id == id);
        }
    }
}
