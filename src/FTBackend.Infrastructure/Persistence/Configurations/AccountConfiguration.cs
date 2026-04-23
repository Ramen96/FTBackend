// src/FTBackend.Infrastructure/Persistence/Configurations/AccountConfiguration.cs
using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.UserId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Balance)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(a => a.Type)
            .IsRequired()
            .HasConversion<string>();

        builder.HasIndex(a => a.UserId);

        // One account has many transactions
        builder.HasMany(a => a.Transactions)
            .WithOne()
            .HasForeignKey(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
