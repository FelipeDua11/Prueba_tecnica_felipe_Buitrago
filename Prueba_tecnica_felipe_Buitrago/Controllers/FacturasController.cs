using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_tecnica_felipe_Buitrago.Class;
using Prueba_tecnica_felipe_Buitrago.Context;

namespace Prueba_tecnica_felipe_Buitrago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacturasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facturas>>> GetBills()
        {
            return await _context.Bills.ToListAsync();
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facturas>> GetFacturas(int id)
        {
            var facturas = await _context.Bills.FindAsync(id);

            if (facturas == null)
            {
                return NotFound();
            }

            return facturas;
        }

        // PUT: api/Facturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturas(int id, Facturas facturas)
        {
            if (id != facturas.Id)
            {
                return BadRequest();
            }

            _context.Entry(facturas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturasExists(id))
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

        // POST: api/Facturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facturas>> PostFacturas(Facturas facturas)
        {
            _context.Bills.Add(facturas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturas", new { id = facturas.Id }, facturas);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturas(int id)
        {
            var facturas = await _context.Bills.FindAsync(id);
            if (facturas == null)
            {
                return NotFound();
            }

            _context.Bills.Remove(facturas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturasExists(int id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}
