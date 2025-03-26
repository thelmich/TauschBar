using Microsoft.EntityFrameworkCore;
using TauschbarAPI.Models;

namespace TauschbarAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Offer> Offers => Set<Offer>();
        public DbSet<ExchangeProposal> ExchangeProposals => Set<ExchangeProposal>();
    }
}