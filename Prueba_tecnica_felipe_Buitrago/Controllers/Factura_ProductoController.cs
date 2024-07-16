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
    public class Factura_ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Factura_ProductoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Factura_Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura_Producto>>> GetBills_Products()
        {
            return await _context.Bills_Products.ToListAsync();
        }

        // GET: api/Factura_Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura_Producto>> GetFactura_Producto(int id)
        {
            var factura_Producto = await _context.Bills_Products.FindAsync(id);

            if (factura_Producto == null)
            {
                return NotFound();
            }

            return factura_Producto;
        }

        // PUT: api/Factura_Producto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura_Producto(int id, Factura_Producto factura_Producto)
        {
            if (id != factura_Producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(factura_Producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Factura_ProductoExists(id))
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

        // POST: api/Factura_Producto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factura_Producto>> PostFactura_Producto(Factura_Producto factura_Producto)
        {
            _context.Bills_Products.Add(factura_Producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactura_Producto", new { id = factura_Producto.Id }, factura_Producto);
        }

        // DELETE: api/Factura_Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura_Producto(int id)
        {
            var factura_Producto = await _context.Bills_Products.FindAsync(id);
            if (factura_Producto == null)
            {
                return NotFound();
            }

            _context.Bills_Products.Remove(factura_Producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Factura_ProductoExists(int id)
        {
            return _context.Bills_Products.Any(e => e.Id == id);
        }
    }
}
