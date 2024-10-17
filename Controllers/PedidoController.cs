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
    public class TiendaController3 : ControllerBase
    {
        private readonly TiendaContext _context;

        public TiendaController3(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/TiendaController3
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidos>>> GetPedido()
        {
            return await _context.Pedido.ToListAsync();
        }

        // GET: api/TiendaController3/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> GetPedidos(int id)
        {
            var pedidos = await _context.Pedido.FindAsync(id);

            if (pedidos == null)
            {
                return NotFound();
            }

            return pedidos;
        }

        // PUT: api/TiendaController3/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidos(int id, Pedidos pedidos)
        {
            if (id != pedidos.id)
            {
                return BadRequest();
            }

            _context.Entry(pedidos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosExists(id))
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

        // POST: api/TiendaController3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedidos>> PostPedidos(Pedidos pedidos)
        {
            _context.Pedido.Add(pedidos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidos", new { id = pedidos.id }, pedidos);
        }

        // DELETE: api/TiendaController3/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidos(int id)
        {
            var pedidos = await _context.Pedido.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedidos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidosExists(int id)
        {
            return _context.Pedido.Any(e => e.id == id);
        }
    }
}
