using Microsoft.EntityFrameworkCore;
using School.Domain.Contracts;
using School.Persistence.Data.DbContexts;

namespace School.API.Extensions
{
    public static class WebApplicationRegister
    {
        public static async Task<WebApplication> MigrateDataBaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
            var PendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
            if (PendingMigrations.Any())
            {
                dbContext.Database.Migrate();
            }

            return app;
        }
        public static async Task<WebApplication> SeedDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dataInitializer = scope.ServiceProvider.GetRequiredKeyedService<IDataInitializer>(
                "Default");
            await dataInitializer.InitializeAsync();
            return app;
        }
    }
}
