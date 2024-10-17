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
    public class TiendaController : ControllerBase
    {
        private readonly TiendaContext _context;

        public TiendaController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Tienda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Tienda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(long id)
        {
            var usuarios = await _context.Usuario.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        // PUT: api/Tienda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(long id, Usuarios usuarios)
        {
            if (id != usuarios.id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Tienda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuarios)
        {
            _context.Usuario.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuarios.id }, usuarios);
        }
        // DELETE: api/Tienda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(long id)
        {
            var usuarios = await _context.Usuario.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosExists(long id)
        {
            return _context.Usuario.Any(e => e.id == id);
        }
    }
}
