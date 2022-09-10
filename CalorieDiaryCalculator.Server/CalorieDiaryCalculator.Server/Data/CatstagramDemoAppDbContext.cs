using CatstagramDemoApp.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatstagramDemoApp.Server.Data {
    public class CatstagramDemoAppDbContext : IdentityDbContext<User> {
        public CatstagramDemoAppDbContext(DbContextOptions<CatstagramDemoAppDbContext> options)
            : base(options) {
        }
    }
}