namespace FTBackend.Core.Entities;

public class BusinessAsset : Asset
{
    public decimal MonthlyDistribution { get; set; }

    public override decimal MonthlyIncome => MonthlyDistribution;
    public override decimal? UnrealizedGrowth => null;
}
