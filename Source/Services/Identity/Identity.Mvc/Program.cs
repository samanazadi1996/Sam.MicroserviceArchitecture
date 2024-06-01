using Identity.Data.Context;
using Identity.Mvc.Infrastracture.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(IdentityServerConfigurations.GetIdentityResources())
    .AddInMemoryApiScopes(IdentityServerConfigurations.GetApiScopes())
    .AddInMemoryClients(IdentityServerConfigurations.GetClients())
    .AddInMemoryApiResources(IdentityServerConfigurations.GetApiResources());

builder.Services.AddTransient<DataSeeder>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await services.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
    await services.GetRequiredService<DataSeeder>().SeedAsync();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();