using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VocaApi.Models;

namespace VocaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocasController : ControllerBase
    {
        private readonly VocaContext _context;

        public VocasController(VocaContext context)
        {
            _context = context;
        }

        // GET: api/Vocas
        [HttpGet]
        public IEnumerable<Voca> Get()
        {
            var voca = _context.Voca;
            return voca;

        }

        // GET: api/Vocas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voca>> GetVoca(int id)
        {
            var voca = await _context.Voca.FindAsync(id);

            if (voca == null)
            {
                return NotFound();
            }

            return voca;
        }

        // PUT: api/Vocas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoca(int id, Voca voca)
        {
            if (id != voca.Id)
            {
                return BadRequest();
            }

            _context.Entry(voca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VocaExists(id))
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

        // POST: api/Vocas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Voca>> PostVoca(Voca voca)
        {
            _context.Voca.Add(voca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoca", new { id = voca.Id }, voca);
        }

        // DELETE: api/Vocas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Voca>> DeleteVoca(int id)
        {
            var voca = await _context.Voca.FindAsync(id);
            if (voca == null)
            {
                return NotFound();
            }

            _context.Voca.Remove(voca);
            await _context.SaveChangesAsync();

            return voca;
        }

        private bool VocaExists(int id)
        {
            return _context.Voca.Any(e => e.Id == id);
        }
    }
}
