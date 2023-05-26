using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegContext _context;

        public RegisterController(RegContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetRegisters()
        {
            if (_context.Registers == null)
            {
                return NotFound();
            }
            return await _context.Registers.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetRegister(int id)
        {
            if (_context.Registers == null)
            {
                return NotFound();
            }
            var user = await _context.Registers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Register register)
        {
            if (id != register.RegId)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Register>> PostUser(Register register)
        {
            if (_context.Registers == null)
            {
                return Problem("Entity set 'ProjectContext.Users'  is null.");
            }
            _context.Registers.Add(register);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = register.RegId }, register);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Registers == null)
            {
                return NotFound();
            }
            var user = await _context.Registers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Registers.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Registers?.Any(e => e.RegId == id)).GetValueOrDefault();
        }
    }
}
