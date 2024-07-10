using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TenantModelsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TenantModelsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tenantModels = await _context.TenantModels.ToListAsync();
        return Ok(tenantModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var tenantModel = await _context.TenantModels.FindAsync(id);
        if (tenantModel == null)
        {
            return NotFound();
        }

        return Ok(tenantModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TenantModel model)
    {
        _context.TenantModels.Add(model);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TenantModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        _context.Entry(model).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TenantModels.Any(e => e.Id == id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var model = await _context.TenantModels.FindAsync(id);
        if (model == null)
        {
            return NotFound();
        }

        _context.TenantModels.Remove(model);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}