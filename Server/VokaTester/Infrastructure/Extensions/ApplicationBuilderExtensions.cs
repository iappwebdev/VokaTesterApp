namespace VokaTester.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using VokaTester.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "VokaTester v1");
                    options.RoutePrefix = string.Empty;
                });

        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope services = app.ApplicationServices.CreateScope();

            VokaTesterDbContext dbContext = services.ServiceProvider.GetService<VokaTesterDbContext>();
            dbContext.Database.Migrate();

            return app;
        }
    }
}
