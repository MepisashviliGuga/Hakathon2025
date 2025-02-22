using Hakathon.Domain;
using Microsoft.EntityFrameworkCore;
namespace Hakathon.persistance.context

{
    public class HakathonContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<History> HistoryRecords { get; set; }
        public DbSet<Card> Cards { get; set; }
        public HakathonContext(DbContextOptions<HakathonContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HakathonContext).Assembly);
        }
    }
}
