using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class PayPeriodEntryConfiguration : IEntityTypeConfiguration<PayPeriodEntry>
{
  public void Configure(EntityTypeBuilder<PayPeriodEntry> builder)
  {
    builder.HasKey(p => p.Id);
    builder.Property(p => p.HoursWorked).HasPrecision(9, 2);
    builder.Property(p => p.OvertimeHours).HasPrecision(9, 2);
    builder.Property(p => p.OvertimeMultiplier).HasPrecision(5, 2);
    builder.HasIndex(p => new { p.IncomeSourceId, p.PeriodStartDate }).IsUnique();
  }
}

