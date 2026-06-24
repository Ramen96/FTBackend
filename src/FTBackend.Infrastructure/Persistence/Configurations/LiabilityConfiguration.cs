using FTBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTBackend.Infrastructure.Persistence.Configurations;

public class LiabilityConfiguration : IEntityTypeConfiguration<Liability>
{
    public void Configure(EntityTypeBuilder<Liability> builder)
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

        builder.Property(t => t.Balance)
          .IsRequired()
          .HasPrecision(18, 2);

        builder.Property(t => t.Payment)
          .IsRequired()
          .HasPrecision(18, 2);
          
        builder.Property(t => t.Rate)
          .IsRequired()
          .HasPrecision(18, 2);

        builder.HasIndex(t => t.UserId);
    }
}
