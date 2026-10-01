using FTBackend.Core.DTOs;
using FTBackend.Core.Entities;

namespace FTBackend.Core.Mapping;

public static class IncomeSourceMapper
{
    public static IncomeSourceDto ToDto(this IncomeSource incomeSource) => new(
        incomeSource.Id,
        incomeSource.Name,
        incomeSource.PayType,
        incomeSource.TaxRate,
        incomeSource.AnnualAmount,
        incomeSource.HourlyRate,
        incomeSource.DefaultHoursPerWeek,
        incomeSource.Frequency,
        incomeSource.MonthlyAmount,
        incomeSource.MonthlyGross,
        incomeSource.MonthlyNet
    );

    public static IncomeSource ToEntity(this CreateIncomeSourceRequest request, string userId) => new()
    {
        UserId = userId,
        Name = request.Name,
        PayType = request.PayType,
        TaxRate = request.TaxRate,
        AnnualAmount = request.AnnualAmount,
        HourlyRate = request.HourlyRate,
        DefaultHoursPerWeek = request.DefaultHoursPerWeek,
        Frequency = request.Frequency,
        MonthlyAmount = request.MonthlyAmount
    };

    public static PayPeriodEntryDto ToDto(this PayPeriodEntry entry) => new(
        entry.Id,
        entry.PeriodStartDate,
        entry.HoursWorked,
        entry.OvertimeHours,
        entry.OvertimeMultiplier
    );
}
