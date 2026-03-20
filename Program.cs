using forge_energy.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ForgeEnergyContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlitedev"));
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
