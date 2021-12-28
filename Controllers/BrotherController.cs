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
    }
}
