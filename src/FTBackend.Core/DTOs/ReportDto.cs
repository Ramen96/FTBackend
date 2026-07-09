using FTBackend.Core.DTOs;

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


public record AssetItemDto(
    Guid Id,
    string Name,
    decimal? Quantity,
    decimal Value,
    decimal Rate
);

public record LiabilityItemDto(
    Guid Id,
    string Name,
    decimal Balance,
    decimal Payment,
    decimal Rate
);
