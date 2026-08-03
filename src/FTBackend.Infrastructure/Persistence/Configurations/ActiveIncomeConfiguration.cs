using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class ActiveIncomeConfiguration : IEntityTypeConfiguration<ActiveIncome>
{
    public void Configure(EntityTypeBuilder<ActiveIncome> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.UserId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.Amount)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.HasIndex(a => a.UserId)
            .IsUnique();
    }
}
