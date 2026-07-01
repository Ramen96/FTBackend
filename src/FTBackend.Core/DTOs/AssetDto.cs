using FTBackend.Core.Entities;

namespace FTBackend.Core.DTOs;

public record CreateAssetRequest(
    string Name,
    AssetCategory Category,
    decimal? Quantity,
    decimal Value,
    decimal Rate
);

public record UpdateAssetRequest(
    string? Name,
    AssetCategory? Category,
    decimal? Quantity,
    decimal? Value,
    decimal? Rate
);
