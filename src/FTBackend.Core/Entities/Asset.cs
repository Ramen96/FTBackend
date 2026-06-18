public class Asset
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public AssetCategory Category { get; set; }
    public decimal? Quantity { get; set; }
    public decimal Value { get; set; }
    public string IncomeOrRate { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public enum AssetCategory { ProducingAssets, GrowthAssets }
