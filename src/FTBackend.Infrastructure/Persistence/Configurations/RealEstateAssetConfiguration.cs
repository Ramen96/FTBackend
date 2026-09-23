using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class RealEstateAssetConfiguration : IEntityTypeConfiguration<RealEstateAsset>
{
    public void Configure(EntityTypeBuilder<RealEstateAsset> builder)
    {
        builder.Property(t => t.PurchasePrice).HasPrecision(18, 2);
        builder.Property(t => t.PurchaseDate).HasColumnName("RealEstatePurchaseDate");
        builder.Property(t => t.NetMonthlyRent).HasPrecision(18, 2);
    }
}
