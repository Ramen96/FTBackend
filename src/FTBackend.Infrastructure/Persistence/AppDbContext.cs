// src/FTBackend.Infrastructure/Persistence/AppDbContext.cs
using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FTBackend.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Liability> Liabilitys => Set<Liability>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
