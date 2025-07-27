//using BL.Api;
//using Dal.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//[ApiController]
//[Route("api/[controller]")]
//public class PaymentController : ControllerBase
//{
//    private readonly IBLPayment _blPayment;

//    public PaymentController(IBLPayment blPayment)
//    {
//        _blPayment = blPayment;
//    }

//    [HttpGet("sum")]
//    public async Task<decimal> GetSumAsync()
//    {
//        return await _blPayment.GetSumAsync();
//    }

//    [HttpGet("user/sum/{userId}")]
//    public async Task<decimal> GetSumByUserId(int userId)
//    {
//        return await _blPayment.GetSumByUserIdAsync(userId);
//    }

//    [HttpGet]
//    public async Task<IEnumerable<Payment>> GetAll()
//    {
//        return await _blPayment.GetAllAsync();
//    }

//    [HttpGet("user/{userId}")]
//    public async Task<IEnumerable<Payment>> GetAllByUserId(int userId)
//    {
//        return await _blPayment.GetAllByUserIdAsync(userId);
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<Payment>> GetById(int id)
//    {
//        var payment = await _blPayment.GetByIdAsync(id);
//        if (payment == null)
//            return NotFound();
//        return payment;
//    }

//    [HttpPost]
//    public async Task<IActionResult> Add([FromBody] Payment payment)
//    {
//        await _blPayment.AddAsync(payment);
//        return CreatedAtAction(nameof(GetById), new { id = payment.PaymentId }, payment);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> Update(int id, [FromBody] Payment payment)
//    {
//        if (id != payment.PaymentId)
//            return BadRequest();

//        await _blPayment.UpdateAsync(payment);
//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(int id)
//    {
//        await _blPayment.DeleteAsync(id);
//        return NoContent();
//    }
//}
using BL.Api;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IBLPayment _blPayment;

    public PaymentController(IBLPayment blPayment)
    {
        _blPayment = blPayment;
    }

    [HttpGet("sum")]
    public async Task<decimal> GetSumAsync()
    {
        return await _blPayment.GetSumAsync();
    }

    [HttpGet("user/sum/{userId}")]
    public async Task<decimal> GetSumByUserIdAsync(int userId)
    {
        return await _blPayment.GetSumByUserIdAsync(userId);
    }

    [HttpGet]
    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await _blPayment.GetAllAsync();
    }

    [HttpGet("user/{userId}")]
    public async Task<IEnumerable<Payment>> GetAllByUserIdAsync(int userId)
    {
        return await _blPayment.GetAllByUserIdAsync(userId);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Payment>> GetByIdAsync(int id)
    {
        var payment = await _blPayment.GetByIdAsync(id);
        if (payment == null)
            return NotFound();
        return payment;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Payment payment)
    {
        await _blPayment.AddAsync(payment);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = payment.PaymentId }, payment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Payment payment)
    {
        if (id != payment.PaymentId)
            return BadRequest();

        await _blPayment.UpdateAsync(payment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _blPayment.DeleteAsync(id);
        return NoContent();
    }
    [HttpGet("summary")]
    public async Task<IActionResult> GetPaymentsSummary()
    {
        var summary = await _blPayment.GetPaymentsSummaryAsync();
        return Ok(new
        {
            current = summary.current,
            previous = summary.previous,
            percentChange = summary.percentChange
        });
    }
}
