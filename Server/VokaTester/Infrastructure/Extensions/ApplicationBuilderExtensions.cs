namespace VokaTester.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using VokaTester.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope services = app.ApplicationServices.CreateScope();

            VokaTesterDbContext dbContext = services.ServiceProvider.GetService<VokaTesterDbContext>();
            dbContext.Database.Migrate();

            return app;
        }

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    if (env.IsDevelopment())
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "VokaTester v1");
                    }
                    else
                    {
                        options.SwaggerEndpoint("/backend/swagger/v1/swagger.json", "VokaTester v1");
                    }
                });
    }
}
