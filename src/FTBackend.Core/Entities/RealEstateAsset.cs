namespace FTBackend.Core.Entities;

public class RealEstateAsset : Asset
{
    public decimal PurchasePrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal NetMonthlyRent { get; set; }

    public override decimal MonthlyIncome => NetMonthlyRent;
    public override decimal? UnrealizedGrowth => Value - PurchasePrice;
}
