using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tethkar.Data.Data;
using Tethkar.Data.DTOs;
using Tethkar.Data.Models;

namespace Tethkar.API.Extensions;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services, IConfiguration configuration)
    {
        #region Configure JWT Settings
        services.Configure<JWT>(configuration.GetSection("JWT"));
        #endregion

        #region Configure Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        #endregion

        #region Add Controllers + OpenAPI
        services.AddControllers();
        services.AddOpenApi();
        #endregion

        #region Configure CORS
        services.AddCors(options =>
        {
            options.AddPolicy("TethkarAPI", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        #endregion

        #region Configure JWT Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = false;

            // This makes sure the JWT key exists in appsettings.json before using it
            var jwtKey = configuration["JWT:Key"]
                ?? throw new InvalidOperationException("JWT:Key is missing from appsettings.json");

            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ClockSkew = TimeSpan.Zero
            };
        });
        #endregion

        return services;
    }
}