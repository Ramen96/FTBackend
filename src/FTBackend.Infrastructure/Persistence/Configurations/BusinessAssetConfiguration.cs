using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class BusinessAssetConfiguration : IEntityTypeConfiguration<BusinessAsset>
{
    public void Configure(EntityTypeBuilder<BusinessAsset> builder)
    {
        builder.Property(t => t.MonthlyDistribution).HasPrecision(18, 2);
    }
}
