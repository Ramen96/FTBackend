using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class StockAssetConfiguration : IEntityTypeConfiguration<StockAsset>
{
  public void Configure(EntityTypeBuilder<StockAsset> builder)
  {
    builder.Property(t => t.Symbol)
      .IsRequired()
      .HasMaxLength(20)
      .HasColumnName("StockSymbol");

    builder.Property(t => t.Quantity).HasPrecision(18, 4).HasColumnName("StockQuantity");
    builder.Property(t => t.CostBasis).HasPrecision(18, 4).HasColumnName("StockCostBasis");
    builder.Property(t => t.PurchaseDate).HasColumnName("StockPurchaseDate");
    builder.Property(t => t.DividendYieldPercent).HasPrecision(9, 4);
    builder.Property(t => t.LastPrice).HasPrecision(18, 4).HasColumnName("StockLastPrice");
    builder.Property(t => t.PriceUpdatedAt).HasColumnName("StockPriceUpdatedAt");
  }
}
