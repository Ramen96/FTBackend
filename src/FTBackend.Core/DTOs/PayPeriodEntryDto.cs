namespace FTBackend.Core.DTOs;

public record LogPayPeriodRequest(
    DateTime PeriodStartDate,
    decimal? HoursWorked = null,
    decimal OvertimeHours = 0m,
    decimal OvertimeMultiplier = 1.5m
);

public record PayPeriodEntryDto(
    Guid Id,
    DateTime PeriodStartDate,
    decimal? HoursWorked,
    decimal OvertimeHours,
    decimal OvertimeMultiplier
);
