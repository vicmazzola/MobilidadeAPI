using Microsoft.AspNetCore.Mvc;
using MobilidadeAPI.Data;
using MobilidadeAPI.Models;

namespace MobilidadeAPI.Controllers;

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
    public ActionResult<IEnumerable<Transport>> GetAll()
    {
        return Ok(_context.Transports.ToList());
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
        _context.Transports.Add(transport);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = transport.Id }, transport);
    }

    // DELETE /transports/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var transport = _context.Transports.Find(id);
        if (transport == null) return NotFound();

        _context.Transports.Remove(transport);
        _context.SaveChanges();
        return NoContent();
    }
}
