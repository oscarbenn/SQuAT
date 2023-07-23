using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQuATStation.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SQuATStationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQuATStationContext")));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<SQuATStationContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SQuATStationContext")));
}
else
{
    builder.Services.AddDbContext<SQuATStationContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionSQuATStationContext")));
}

builder.Services.AddDbContext<SQuATStationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQuATStationContext") ?? throw new InvalidOperationException("Connection string 'SQuATStationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/");

app.Run();
