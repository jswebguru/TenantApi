using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Abstractions;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

public class AppDbContext : MultiTenantContext<TenantInfo>
{
    public AppDbContext(ITenantInfo tenantInfo, DbContextOptions<AppDbContext> options)
        : base(
            tenantInfo,
            options)
    {
    }

    public DbSet<TenantModel> TenantModels { get; set; }
}