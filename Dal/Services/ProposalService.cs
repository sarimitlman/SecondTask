using Dal.Api;
using Dal.DBContext;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProposalService : IProposal
{
    private readonly CrmDbContext _context;

    public ProposalService(CrmDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Proposal>> GetAllAsync() => await _context.Proposals.ToListAsync();
    public async Task<Proposal> GetByIdAsync(int id) => await _context.Proposals.FindAsync(id);
    public async Task AddAsync(Proposal entity)
    {
        await _context.Proposals.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Proposal entity)
    {
        _context.Proposals.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var proposal = await _context.Proposals.FindAsync(id);
        if (proposal != null)
        {
            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();
        }
    }
}