using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add MultiTenant and EF Core services
builder.Services.AddMultiTenant<TenantInfo>()
                .WithConfigurationStore()
                .WithRouteStrategy();

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var tenantInfo = serviceProvider.GetRequiredService<ITenantInfo>();

    if (!string.IsNullOrEmpty(tenantInfo.ConnectionString))
    {
        options.UseSqlServer(tenantInfo.ConnectionString);
    }
    else
    {
        // Default to fallback connection string if required
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseMultiTenant();

app.UseAuthorization();

app.MapControllers();

app.Run();