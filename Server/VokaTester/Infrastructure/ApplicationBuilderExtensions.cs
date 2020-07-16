namespace VokaTester.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using VokaTester.Data;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope services = app.ApplicationServices.CreateScope();

            VokaTesterDbContext dbContext = services.ServiceProvider.GetService<VokaTesterDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
