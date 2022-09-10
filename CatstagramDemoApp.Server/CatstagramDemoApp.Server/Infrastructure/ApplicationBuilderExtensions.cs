using CatstagramDemoApp.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CatstagramDemoApp.Server.Infrastructure {
    public static class ApplicationBuilderExtensions {
        public static void ApplyMigration(this IApplicationBuilder app) {
            using var services = app.ApplicationServices.CreateScope();
            var dbContext = services.ServiceProvider.GetService<CatstagramDemoAppDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
