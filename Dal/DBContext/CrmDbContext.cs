using Dal.Models;
using Microsoft.EntityFrameworkCore;
namespace Dal.DBContext
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        //public DbSet<EmailCampaign> EmailCampaigns { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}