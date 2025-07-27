using Dal.Api;
using Dal.DBContext;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ClientService : IClient
{
    private readonly CrmDbContext _context;

    public ClientService(CrmDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync() => await _context.Clients.ToListAsync();
    public async Task<Client> GetByIdAsync(int id) => await _context.Clients.FindAsync(id);
    public async Task AddAsync(Client entity)
    {
        await _context.Clients.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Client entity)
    {
        _context.Clients.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}