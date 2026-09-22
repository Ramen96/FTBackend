namespace FTBackend.Core.Entities;

public class StockAsset: Asset {

  public string Symbol { get; set; } = string.Empty;
  public decimal Quantity { get; set; }
  public decimal CostBasis { get; set; }
  public DateTime PurchaseDate { get; set; }
  public decimal DividendYieldPercent { get; set; }
  public decimal? LastPrice { get; set; }
  public DateTime? PriceUpdatedAt { get; set; }

  public override decimal MonthlyIncome => Value * DividendYieldPercent / 100 / 12;
  public override decimal? UnrealizedGrowth => (LastPrice ?? Value) - CostBasis * Quantity;
}
