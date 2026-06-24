using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserId)
          .IsRequired()
          .HasMaxLength(255);

        builder.Property(t => t.Name)
          .IsRequired()
          .HasMaxLength(100);

        builder.Property(t => t.Category)
          .IsRequired()
          .HasConversion<string>();

        builder.Property(t => t.Quantity)
          .HasPresision(18, 2);

        builder.Property(t => t.Value)
          .IsRequired()
          .HasPresision(18, 2);
          
        builder.Property(t => t.Rate)
          .IsRequired()
          .HasPresision(18, 2);
    }
}
