using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heroes.Data;
using Heroes.Models;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HosokController : ControllerBase
    {
        private readonly HeroesContext _context;

        public HosokController(HeroesContext context)
        {
            _context = context;
        }

        // GET: api/hosok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hos>>> GetHosok()
        {
            return await _context.Hosok.Include(h => h.Kaszt).ToListAsync();
        }

        // POST: api/hosok
        [HttpPost]
        public async Task<ActionResult<Hos>> PostHos(Hos hos)
        {
            if (hos.KasztId == 0)
            {
                 return BadRequest(new { error = "Hiányzó adatok: kasztId megadása kötelező." });
            }

             // Basic validation for required fields if needed, though [ApiController] does some automatically.
            if (string.IsNullOrEmpty(hos.Nev) || string.IsNullOrEmpty(hos.Szarmazas))
            {
                return BadRequest(new { error = "Hiányzó adatok: név és származás megadása kötelező." });
            }

            // Verify Kaszt exists
            var kaszt = await _context.Kasztok.FindAsync(hos.KasztId);
            if (kaszt == null)
            {
                return BadRequest(new { error = "Érvénytelen kasztId." });
            }
            
            hos.Kaszt = null; // Avoid cycle or re-insertion issues if client sends full object

            _context.Hosok.Add(hos);
            await _context.SaveChangesAsync();

            // Return 201 Created with a standard response body if requested, or just the object.
            // The prompt asks for:
            // Válasz: 201
            // { "message": "Sikeresen hozzáadva" }
            
            return StatusCode(201, new { message = "Sikeresen hozzáadva" });
        }
    }
}
