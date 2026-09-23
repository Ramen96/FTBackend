using System.Text.Json.Serialization;

namespace FTBackend.Core.DTOs;

public record ReportDto<T>(
    IEnumerable<ReportCategoryDto<T>> Categories,
    decimal Total
);

public record ReportCategoryDto<T>(
    string Name,
    IEnumerable<T> Items
);

public record TransactionItemDto(
    Guid Id,
    string Category,
    string Description,
    decimal Amount
);

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(StockAssetItemDto), "stock")]
[JsonDerivedType(typeof(SavingsAssetItemDto), "savings")]
[JsonDerivedType(typeof(RealEstateAssetItemDto), "realEstate")]
[JsonDerivedType(typeof(BusinessAssetItemDto), "business")]
[JsonDerivedType(typeof(CryptoAssetItemDto), "crypto")]
[JsonDerivedType(typeof(CustomAssetItemDto), "custom")]
public abstract record AssetItemDto(
    Guid Id,
    string Name,
    decimal Value,
    decimal MonthlyIncome,
    decimal? UnrealizedGrowth
);

public record StockAssetItemDto(
    Guid Id, string Name, decimal Value, decimal MonthlyIncome, decimal? UnrealizedGrowth,
    string Symbol, decimal Quantity, decimal CostBasis, DateTime PurchaseDate,
    decimal DividendYieldPercent, decimal? LastPrice
) : AssetItemDto(Id, Name, Value, MonthlyIncome, UnrealizedGrowth);

public record SavingsAssetItemDto(
    Guid Id, string Name, decimal Value, decimal MonthlyIncome, decimal? UnrealizedGrowth,
    decimal ApyPercent
) : AssetItemDto(Id, Name, Value, MonthlyIncome, UnrealizedGrowth);

public record RealEstateAssetItemDto(
    Guid Id, string Name, decimal Value, decimal MonthlyIncome, decimal? UnrealizedGrowth,
    decimal PurchasePrice, DateTime PurchaseDate, decimal NetMonthlyRent
) : AssetItemDto(Id, Name, Value, MonthlyIncome, UnrealizedGrowth);

public record BusinessAssetItemDto(
    Guid Id, string Name, decimal Value, decimal MonthlyIncome, decimal? UnrealizedGrowth,
    decimal MonthlyDistribution
) : AssetItemDto(Id, Name, Value, MonthlyIncome, UnrealizedGrowth);

public record CryptoAssetItemDto(
    Guid Id, string Name, decimal Value, decimal MonthlyIncome, decimal? UnrealizedGrowth,
    string Symbol, decimal Quantity, decimal CostBasis, DateTime PurchaseDate, decimal? LastPrice
) : AssetItemDto(Id, Name, Value, MonthlyIncome, UnrealizedGrowth);

public record CustomAssetItemDto(
    Guid Id, string Name, decimal Value, decimal MonthlyIncome, decimal? UnrealizedGrowth,
    string CustomTypeLabel, decimal? YieldPercent, decimal? MonthlyIncomeOverride, decimal? CostBasis
) : AssetItemDto(Id, Name, Value, MonthlyIncome, UnrealizedGrowth);

public record LiabilityItemDto(
    Guid Id,
    string Name,
    decimal Balance,
    decimal Payment,
    decimal Rate
);
