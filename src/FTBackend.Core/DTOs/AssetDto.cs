using FTBackend.Core.Entities;
using System.Text.Json.Serialization;

namespace FTBackend.Core.DTOs;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(CreateStockAssetRequest), "stock")]
[JsonDerivedType(typeof(CreateSavingsAssetRequest), "savings")]
[JsonDerivedType(typeof(CreateRealEstateAssetRequest), "realEstate")]
[JsonDerivedType(typeof(CreateBusinessAssetRequest), "business")]
[JsonDerivedType(typeof(CreateCryptoAssetRequest), "crypto")]
[JsonDerivedType(typeof(CreateCustomAssetRequest), "custom")]
public abstract record CreateAssetRequest(string Name, decimal Value);

public record CreateStockAssetRequest(
    string Name,
    decimal Value,
    string Symbol,
    decimal Quantity,
    decimal CostBasis,
    DateTime PurchaseDate,
    decimal DividendYieldPercent
) : CreateAssetRequest(Name, Value);

public record CreateSavingsAssetRequest(
    string Name,
    decimal Value,
    decimal ApyPercent
) : CreateAssetRequest(Name, Value);

public record CreateRealEstateAssetRequest(
    string Name,
    decimal Value,
    decimal PurchasePrice,
    DateTime PurchaseDate,
    decimal NetMonthlyRent
) : CreateAssetRequest(Name, Value);

public record CreateBusinessAssetRequest(
    string Name,
    decimal Value,
    decimal MonthlyDistribution
) : CreateAssetRequest(Name, Value);

public record CreateCryptoAssetRequest(
    string Name,
    decimal Value,
    string Symbol,
    decimal Quantity,
    decimal CostBasis,
    DateTime PurchaseDate
) : CreateAssetRequest(Name, Value);

public record CreateCustomAssetRequest(
    string Name,
    decimal Value,
    string CustomTypeLabel,
    decimal? YieldPercent,
    decimal? MonthlyIncomeOverride,
    decimal? CostBasis
) : CreateAssetRequest(Name, Value);
