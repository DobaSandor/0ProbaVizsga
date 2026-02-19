using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heroes.Data;
using Heroes.Models;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasztokController : ControllerBase
    {
        private readonly HeroesContext _context;

        public KasztokController(HeroesContext context)
        {
            _context = context;
        }

        // GET: api/kasztok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kaszt>>> GetKasztok()
        {
            return await _context.Kasztok.ToListAsync();
        }
    }
}
