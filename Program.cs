using System.Text;
using forge_energy.Data;
using forge_energy.Entities;
using forge_energy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ForgeEnergyContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlitedev"));
});

// 1. Lägg till inloggningsinställningar (authentication)...
builder.Services.AddIdentityCore<User>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 8;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ForgeEnergyContext>();

// Depency Injection...
// Registera vår TokenServer i dotnet's dependency lista...
builder.Services.AddScoped<TokenService>();

// builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    // Skapa en generell regel(policy) som tvingar alla att vara inloggade...
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    // Applicera regeln...
    options.Filters.Add(new AuthorizeFilter(policy));

});

// 2. Aktivera ett auktoriserings schema, dvs hur ska vi kontrollera användaren...
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("tokenSettings:tokenKey").Value))
        };
    });

// 6. Ett alternativt sätt att koppla behörighet i dotnet...
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireCorporateRights", policy => policy.RequireRole("Admin", "Manager"));

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireAdminRights", policy => policy.RequireRole("Admin"));

// 3. Aktivera behörighetskontroll...
builder.Services.AddAuthorization();

var app = builder.Build();

// 4. Använd användar inloggning i systemet...
app.UseAuthentication();

// 5. Använda behörighetskontroll...
app.UseAuthorization();

app.MapControllers();

app.Run();
