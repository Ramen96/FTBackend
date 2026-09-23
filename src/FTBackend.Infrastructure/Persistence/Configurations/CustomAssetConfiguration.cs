using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class CustomAssetConfiguration : IEntityTypeConfiguration<CustomAsset>
{
    public void Configure(EntityTypeBuilder<CustomAsset> builder)
    {
        builder.Property(t => t.CustomTypeLabel)
          .IsRequired()
          .HasMaxLength(50);

        builder.Property(t => t.YieldPercent).HasPrecision(9, 4);
        builder.Property(t => t.MonthlyIncomeOverride).HasPrecision(18, 2);
        builder.Property(t => t.CostBasis).HasPrecision(18, 2).HasColumnName("CustomCostBasis");
    }
}
