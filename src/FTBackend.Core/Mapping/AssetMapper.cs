using FTBackend.Core.DTOs;
using FTBackend.Core.Entities;

namespace FTBackend.Core.Mapping;

public static class AssetMapper
{
    public static AssetItemDto ToItemDto(this Asset asset) => asset switch
    {
        StockAsset s => new StockAssetItemDto(
            s.Id, s.Name, s.Value, s.MonthlyIncome, s.UnrealizedGrowth,
            s.Symbol, s.Quantity, s.CostBasis, s.PurchaseDate, s.DividendYieldPercent, s.LastPrice),

        SavingsAsset sa => new SavingsAssetItemDto(
            sa.Id, sa.Name, sa.Value, sa.MonthlyIncome, sa.UnrealizedGrowth, sa.ApyPercent),

        RealEstateAsset r => new RealEstateAssetItemDto(
            r.Id, r.Name, r.Value, r.MonthlyIncome, r.UnrealizedGrowth,
            r.PurchasePrice, r.PurchaseDate, r.NetMonthlyRent),

        BusinessAsset b => new BusinessAssetItemDto(
            b.Id, b.Name, b.Value, b.MonthlyIncome, b.UnrealizedGrowth, b.MonthlyDistribution),

        CryptoAsset c => new CryptoAssetItemDto(
            c.Id, c.Name, c.Value, c.MonthlyIncome, c.UnrealizedGrowth,
            c.Symbol, c.Quantity, c.CostBasis, c.PurchaseDate, c.LastPrice),

        CustomAsset cu => new CustomAssetItemDto(
            cu.Id, cu.Name, cu.Value, cu.MonthlyIncome, cu.UnrealizedGrowth,
            cu.CustomTypeLabel, cu.YieldPercent, cu.MonthlyIncomeOverride, cu.CostBasis),

        _ => throw new NotSupportedException($"Unknown asset type: {asset.GetType().Name}")
    };

    public static Asset ToEntity(this CreateAssetRequest request, string userId) => request switch
    {
        CreateStockAssetRequest r => new StockAsset
        {
            UserId = userId,
            Name = r.Name,
            Value = r.Value,
            Symbol = r.Symbol,
            Quantity = r.Quantity,
            CostBasis = r.CostBasis,
            PurchaseDate = r.PurchaseDate,
            DividendYieldPercent = r.DividendYieldPercent
        },

        CreateSavingsAssetRequest r => new SavingsAsset
        {
            UserId = userId,
            Name = r.Name,
            Value = r.Value,
            ApyPercent = r.ApyPercent
        },

        CreateRealEstateAssetRequest r => new RealEstateAsset
        {
            UserId = userId,
            Name = r.Name,
            Value = r.Value,
            PurchasePrice = r.PurchasePrice,
            PurchaseDate = r.PurchaseDate,
            NetMonthlyRent = r.NetMonthlyRent
        },

        CreateBusinessAssetRequest r => new BusinessAsset
        {
            UserId = userId,
            Name = r.Name,
            Value = r.Value,
            MonthlyDistribution = r.MonthlyDistribution
        },

        CreateCryptoAssetRequest r => new CryptoAsset
        {
            UserId = userId,
            Name = r.Name,
            Value = r.Value,
            Symbol = r.Symbol,
            Quantity = r.Quantity,
            CostBasis = r.CostBasis,
            PurchaseDate = r.PurchaseDate
        },

        CreateCustomAssetRequest r => new CustomAsset
        {
            UserId = userId,
            Name = r.Name,
            Value = r.Value,
            CustomTypeLabel = r.CustomTypeLabel,
            YieldPercent = r.YieldPercent,
            MonthlyIncomeOverride = r.MonthlyIncomeOverride,
            CostBasis = r.CostBasis
        },

        _ => throw new NotSupportedException($"Unknown create request type: {request.GetType().Name}")
    };
}
