using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibraryAirline.DBContext;
using ClassLibraryAirline.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineModelsController : ControllerBase
    {
        private readonly DemoDBContext _context;

        public AirlineModelsController(DemoDBContext context)
        {
            _context = context;
        }

        // GET: api/AirlineModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirlineModel>>> GetAirlineModels()
        {
          if (_context.AirlineModels == null)
          {
              return NotFound();
          }
            return await _context.AirlineModels.ToListAsync();
        }

        // GET: api/AirlineModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineModel>> GetAirlineModel(int id)
        {
          if (_context.AirlineModels == null)
          {
              return NotFound();
          }
            var airlineModel = await _context.AirlineModels.FindAsync(id);

            if (airlineModel == null)
            {
                return NotFound();
            }

            return airlineModel;
        }

        // PUT: api/AirlineModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirlineModel(int id, AirlineModel airlineModel)
        {
            if (id != airlineModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(airlineModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineModelExists(id))
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

        // POST: api/AirlineModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirlineModel>> PostAirlineModel(AirlineModel airlineModel)
        {
          if (_context.AirlineModels == null)
          {
              return Problem("Entity set 'DemoDBContext.AirlineModels'  is null.");
          }
            _context.AirlineModels.Add(airlineModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirlineModel", new { id = airlineModel.ID }, airlineModel);
        }

        // DELETE: api/AirlineModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirlineModel(int id)
        {
            if (_context.AirlineModels == null)
            {
                return NotFound();
            }
            var airlineModel = await _context.AirlineModels.FindAsync(id);
            if (airlineModel == null)
            {
                return NotFound();
            }

            _context.AirlineModels.Remove(airlineModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirlineModelExists(int id)
        {
            return (_context.AirlineModels?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
