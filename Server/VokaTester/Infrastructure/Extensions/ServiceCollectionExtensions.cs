﻿namespace VokaTester.Infrastructure.Extensions
{
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using VokaTester.Data;
    using VokaTester.Data.Models;
    using VokaTester.Features.Fortschritt;
    using VokaTester.Features.Identity;
    using VokaTester.Features.Lektionen;
    using VokaTester.Features.StringSimilarity;
    using VokaTester.Features.TestResults;
    using VokaTester.Features.Vokabeln;
    using VokaTester.Features.VokabelSpellCheck;
    using VokaTester.Infrastructure.Filters;
    using VokaTester.Infrastructure.Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddTransient<IFortschrittService, FortschrittService>()
                .AddTransient<IGeneralizeStringService, GeneralizeStringService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ILektionenService, LektionenService>()
                .AddTransient<IStringSimilarityService, StringSimilarityService>()
                .AddTransient<ITestResultsService, TestResultsService>()
                .AddTransient<IVokabelService, VokabelService>()
                .AddTransient<IVokabelSpellCheckService, VokabelSpellCheckService>();

        public static void AddApiControllers(this IServiceCollection services)
            => services
                .AddControllers(options => options
                    .Filters.Add<ModelOrNotFoundActionFilter>());

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services
                    .AddDbContext<VokaTesterDbContext>(options => options
                        .UseLazyLoadingProxies()
                        .UseSqlServer(configuration.GetDefaultConnectionString()));

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                    .AddIdentity<User, IdentityRole>(options =>
                    {
                        options.User.RequireUniqueEmail = true;
                        options.Password.RequiredLength = 6;
                        options.Password.RequireDigit = true;
                        options.Password.RequireLowercase = true;
                        options.Password.RequireUppercase = true;
                        options.Password.RequireNonAlphanumeric = false;
                    })
                    .AddEntityFrameworkStores<VokaTesterDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "VokaTester API", Version = "v1" });
                });

        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection applicationSettings = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettings);
            return applicationSettings.Get<AppSettings>();
        }
    }
}
