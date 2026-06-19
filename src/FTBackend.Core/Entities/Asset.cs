public class Asset
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public AssetCategory Category { get; set; }
    public decimal? Quantity { get; set; }
    public decimal Value { get; set; }
    public decimal Rate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public enum AssetCategory { ProducingAssets, GrowthAssets }
