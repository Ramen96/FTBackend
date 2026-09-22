namespace FTBackend.Core.Entities;

public class CryptoAsset : Asset
{
    public string Symbol { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal CostBasis { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal? LastPrice { get; set; }
    public DateTime? PriceUpdatedAt { get; set; }

    public override decimal MonthlyIncome => 0m;
    public override decimal? UnrealizedGrowth => (LastPrice ?? Value) - CostBasis * Quantity;
}
