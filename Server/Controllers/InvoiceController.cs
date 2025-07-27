using BL.Api;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IBLInvoice _blInvoice;

    public InvoiceController(IBLInvoice blInvoice)
    {
        _blInvoice = blInvoice;
    }

    [HttpGet("num")]
    public async Task<int> GetSumAsync()
    {
        return await _blInvoice.GetSumAsync();
    }

    [HttpGet("user/num/{userId}")]
    public async Task<int> GetSumByUserIdAsync(int userId)
    {
        return await _blInvoice.GetSumByUserIdAsync(userId);
    }

    [HttpGet]
    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await _blInvoice.GetAllAsync();
    }

    [HttpGet("user/{userId}")]
    public async Task<IEnumerable<Invoice>> GetAllByUserIdAsync(int userId)
    {
        return await _blInvoice.GetAllByUserIdAsync(userId);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Invoice>> GetByIdAsync(int id)
    {
        var invoice = await _blInvoice.GetByIdAsync(id);
        if (invoice == null)
            return NotFound();
        return invoice;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Invoice invoice)
    {
        await _blInvoice.AddAsync(invoice);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = invoice.InvoiceId }, invoice);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Invoice invoice)
    {
        if (id != invoice.InvoiceId)
            return BadRequest();

        await _blInvoice.UpdateAsync(invoice);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _blInvoice.DeleteAsync(id);
        return NoContent();
    }
    [HttpGet("summary")]
    public async Task<IActionResult> GetInvoicesSummary()
    {
        var summary = await _blInvoice.GetInvoicesSummaryAsync();
        return Ok(new
        {
            current = summary.current,
            previous = summary.previous,
            percentChange = summary.percentChange
        });
    }
}