using Microsoft.AspNetCore.Identity;
using Tethkar.API.Extensions;
using Tethkar.Data.Configurations;
using Tethkar.Data.Models;
using Tethkar.Services.Configurations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

#region Register Layers

builder.Services.AddProjectDataLayer(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddApiLayer(builder.Configuration);

#endregion

var app = builder.Build();

#region Seed Roles

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "User", "Admin", "Organizer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

#endregion

#region Development Tools

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

#endregion

#region Middleware Pipeline

app.UseCors("TethkarAPI");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();

#endregion

app.Run();