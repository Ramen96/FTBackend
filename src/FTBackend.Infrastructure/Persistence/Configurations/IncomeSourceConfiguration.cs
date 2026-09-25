using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class IncomeSourceConfiguration : IEntityTypeConfiguration<IncomeSource>
{
  public void Configure(EntityTypeBuilder<IncomeSource> builder)
  {
    builder.HasKey(i => i.Id);

    builder.Property(i => i.UserId)
      .IsRequired()
      .HasMaxLength(255);

    builder.Property(i => i.Name)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(i => i.PayType)
      .IsRequired()
      .HasConversion<string>();

    builder.Property(i => i.Frequency)
      .HasConversion<string>();

    builder.Property(i => i.TaxRate).HasPrecision(9, 4);
    builder.Property(i => i.AnnualAmount).HasPrecision(18, 2);
    builder.Property(i => i.HourlyRate).HasPrecision(18, 4);
    builder.Property(i => i.DefaultHoursPerWeek).HasPrecision(9, 2);
    builder.Property(i => i.MonthlyAmount).HasPrecision(18, 2);

    builder.HasIndex(i => i.UserId);

    builder.HasMany(i => i.PayPeriodEntries)
      .WithOne()
      .HasForeignKey(p => p.IncomeSourceId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
