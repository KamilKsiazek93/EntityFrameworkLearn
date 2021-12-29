using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkLearn.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrotherController : ControllerBase
    {
        private readonly BrothersDbContext _context;
        public BrotherController(BrothersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brother>>> GetBrothers()
        {
            return await _context.Brothers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brother>> GetBrother(int id)
        {
            return await _context.Brothers.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Brother>> PostBrother(Brother brother)
        {
            _context.Brothers.Add(brother);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBrother", new { id = brother.Id }, brother);
        }

        [HttpPost("brothers")]
        public async Task<ActionResult<IEnumerable<Brother>>> PostBrothers(IEnumerable<Brother> brothers)
        {
            await _context.Brothers.AddRangeAsync(brothers);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBrothers", brothers);
        }

        [HttpPut]
        public async Task<IActionResult> PutBrother(int id, Brother brother)
        {
            if(id != brother.Id)
            {
                return BadRequest();
            }
            _context.Entry(brother).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                if(!brotherExist(id))
                {
                    NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Brother>> DeleteBrother(int id)
        {
            var brother = await _context.Brothers.FindAsync(id);
            if (brother == null)
            {
                return NotFound();
            }

            _context.Remove(brother);
            await _context.SaveChangesAsync();

            return brother;
        }

        private bool brotherExist(int id)
        {
            return _context.Brothers.Any(brother => brother.Id == id);
        }
    }
}
