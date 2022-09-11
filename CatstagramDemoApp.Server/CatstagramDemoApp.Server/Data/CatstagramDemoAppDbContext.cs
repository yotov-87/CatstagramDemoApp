using CatstagramDemoApp.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatstagramDemoApp.Server.Data {
    public class CatstagramDemoAppDbContext : IdentityDbContext<User> {
        public CatstagramDemoAppDbContext(DbContextOptions<CatstagramDemoAppDbContext> options)
            : base(options) {
        }

        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder
                .Entity<Cat>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cats)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}