using FTBackend.Core.Entities;
namespace FTBackend.Core.DTOs;

public record CreateIncomeSourceRequest(
    string Name, PayType PayType, decimal TaxRate,
    decimal? AnnualAmount,
    decimal? HourlyRate, decimal? DefaultHoursPerWeek, PayPeriod? Frequency,
    decimal? MonthlyAmount
);

public record IncomeSourceDto(
    Guid Id, string Name, PayType PayType, decimal TaxRate,
    decimal? AnnualAmount,
    decimal? HourlyRate, decimal? DefaultHoursPerWeek, PayPeriod? Frequency,
    decimal? MonthlyAmount,
    decimal MonthlyGross, decimal MonthlyNet
);
