using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : MultiTenantDbContext<TenantInfo>
{
    public AppDbContext(TenantInfo tenantInfo, DbContextOptions<AppDbContext> options)
        : base(tenantInfo, options)
    { }

    public DbSet<TenantModel> TenantModels { get; set; }
}