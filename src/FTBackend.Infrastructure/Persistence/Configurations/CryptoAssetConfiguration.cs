using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class CryptoAssetConfiguration : IEntityTypeConfiguration<CryptoAsset>
{
    public void Configure(EntityTypeBuilder<CryptoAsset> builder)
    {
        builder.Property(t => t.Symbol)
          .IsRequired()
          .HasMaxLength(20)
          .HasColumnName("CryptoSymbol");

        builder.Property(t => t.Quantity).HasPrecision(18, 8).HasColumnName("CryptoQuantity");
        builder.Property(t => t.CostBasis).HasPrecision(18, 8).HasColumnName("CryptoCostBasis");
        builder.Property(t => t.PurchaseDate).HasColumnName("CryptoPurchaseDate");
        builder.Property(t => t.LastPrice).HasPrecision(18, 8).HasColumnName("CryptoLastPrice");
        builder.Property(t => t.PriceUpdatedAt).HasColumnName("CryptoPriceUpdatedAt");
    }
}
