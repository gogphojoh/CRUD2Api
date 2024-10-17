using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD2Api.Models;

namespace CRUD2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController2 : ControllerBase
    {
        private readonly TiendaContext _context;

        public TiendaController2(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/TiendaController2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProducto()
        {
            return await _context.Producto.ToListAsync();
        }

        // GET: api/TiendaController2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductos(int id)
        {
            var productos = await _context.Producto.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/TiendaController2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, Productos productos)
        {
            if (id != productos.id)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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

        // POST: api/TiendaController2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            _context.Producto.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductos), new { id = productos.id }, productos);
        }

        // DELETE: api/TiendaController2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            var productos = await _context.Producto.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(productos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductosExists(int id)
        {
            return _context.Producto.Any(e => e.id == id);
        }
    }
}
