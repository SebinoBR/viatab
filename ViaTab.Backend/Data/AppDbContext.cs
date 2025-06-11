using Microsoft.EntityFrameworkCore;
using ViaTab.Backend.Models;

namespace ViaTab.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        
        public DbSet<Story> Stories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>().HasData(
        new Story { Id = 1, Title = "BREAKING: Architecture Student Builds Something That Doesn't Fall Down!", Content = "Shocking development as Department A student creates structure that remains standing for over 3 hours. Structural integrity experts baffled.", Department = "A" },
        new Story { Id = 2, Title = "SCANDAL: Biology Lab Grows Plant Successfully", Content = "Anonymous tip reveals Department B actually managed to keep something alive for an entire semester. Campus in uproar.", Department = "B" },
        new Story { Id = 3, Title = "EXPOSED: Computer Science Code Compiles on First Try", Content = "Witnesses report Department C student's program worked immediately without debugging. Investigation into possible cheating underway.", Department = "C" }
    );
        }
    }
}