using FTBackend.Core.Entities;

namespace FTBackend.Core.DTOs;

public record CreateLiabilityRequest(
    string Name,
    LiabilityCategory Category,
    decimal Balance,
    decimal Payment,
    decimal Rate
);

public record UpdateLiabilityRequest(
    string? Name,
    LiabilityCategory? Category,
    decimal? Balance,
    decimal? Payment,
    decimal? Rate
);
