using Microsoft.AspNetCore.Mvc;
using MobilidadeAPI.Data;
using MobilidadeAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MobilidadeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransportsController(AppDbContext context)
        {
            _context = context;
        }

        // GET /transports
        [HttpGet]
        public ActionResult<IEnumerable<Transport>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page <= 0 || pageSize <= 0)
                return BadRequest("Page and pageSize must be greater than zero.");

            var transports = _context.Transports
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(transports);
        }

        // GET /transports/{id}
        [HttpGet("{id}")]
        public ActionResult<Transport> GetById(int id)
        {
            var transport = _context.Transports.Find(id);
            if (transport == null) return NotFound();
            return Ok(transport);
        }

        // POST /transports
        [HttpPost]
        public ActionResult<Transport> Create(Transport transport)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Transports.Add(transport);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = transport.Id }, transport);
        }

        // DELETE /transports/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var transport = _context.Transports.Find(id);
                if (transport == null) return NotFound();

                _context.Transports.Remove(transport);
                _context.SaveChanges();
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal error: {ex.Message}");
            }
        }
    }
}
