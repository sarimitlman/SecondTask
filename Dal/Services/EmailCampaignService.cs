namespace Dal.Services { }
//using Dal.Api;
//using Dal.DBContext;
//using Dal.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//public class EmailCampaignService : IEmailCampaign
//{
//    private readonly CrmDbContext _context;

//    public EmailCampaignService(CrmDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<IEnumerable<EmailCampaign>> GetAllAsync() => await _context.EmailCampaigns.ToListAsync();
//    public async Task<EmailCampaign?> GetByIdAsync(int id) => await _context.EmailCampaigns.FindAsync(id);
//    public async Task AddAsync(EmailCampaign entity)
//    {
//        await _context.EmailCampaigns.AddAsync(entity);
//        await _context.SaveChangesAsync();
//    }
//    public async Task UpdateAsync(EmailCampaign entity)
//    {
//        _context.EmailCampaigns.Update(entity);
//        await _context.SaveChangesAsync();
//    }
//    public async Task DeleteAsync(int id)
//    {
//        var campaign = await _context.EmailCampaigns.FindAsync(id);
//        if (campaign != null)
//        {
//            _context.EmailCampaigns.Remove(campaign);
//            await _context.SaveChangesAsync();
//        }
//    }
//}