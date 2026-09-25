using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FTBackend.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Liability> Liabilities => Set<Liability>();
    public DbSet<IncomeSource> IncomeSources => Set<IncomeSource>();
    public DbSet<PayPeriodEntry> PayPeriodEntries => Set<PayPeriodEntry>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
