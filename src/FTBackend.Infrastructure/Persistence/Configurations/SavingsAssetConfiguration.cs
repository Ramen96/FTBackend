using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class SavingsAssetConfiguration : IEntityTypeConfiguration<SavingsAsset>
{
    public void Configure(EntityTypeBuilder<SavingsAsset> builder)
    {
        builder.Property(t => t.ApyPercent).HasPrecision(9, 4);
    }
}
