namespace FTBackend.Core.DTOs;

public record DashboardDto(
    decimal IncomeTotal,
    decimal ExpensesTotal,
    decimal AssetsTotal,
    decimal LiabilitiesTotal
);
