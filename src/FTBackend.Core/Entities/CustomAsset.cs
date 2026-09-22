namespace FTBackend.Core.Entities;

public class CustomAsset : Asset
{
    public string CustomTypeLabel { get; set; } = string.Empty;
    public decimal? YieldPercent { get; set; }
    public decimal? MonthlyIncomeOverride { get; set; }
    public decimal? CostBasis { get; set; }

    public override decimal MonthlyIncome =>
        MonthlyIncomeOverride ?? Value * (YieldPercent ?? 0) / 100 / 12;

    public override decimal? UnrealizedGrowth =>
        CostBasis.HasValue ? Value - CostBasis.Value : null;
}
