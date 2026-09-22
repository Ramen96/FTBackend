namespace FTBackend.Core.Entities;

public class SavingsAsset : Asset
{
    public decimal ApyPercent { get; set; }

    public override decimal MonthlyIncome => Value * ApyPercent / 100 / 12;
    public override decimal? UnrealizedGrowth => null;
}
