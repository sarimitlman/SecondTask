using Dal.Api;
using Dal.DBContext;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InvoiceService: IInvoice
{
    private readonly CrmDbContext _context;

    public InvoiceService(CrmDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync() => await _context.Invoices.ToListAsync();
    public async Task<Invoice> GetByIdAsync(int id) => await _context.Invoices.FindAsync(id);
    public async Task AddAsync(Invoice entity)
    {
        await _context.Invoices.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Invoice entity)
    {
        _context.Invoices.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice != null)
        {
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }
}