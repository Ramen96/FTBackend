namespace FTBackend.Core.Entities;

public class IncomeSource
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string UserId { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public PayType PayType { get; set; }
  public decimal TaxRate { get; set; }

  // Salary
  public decimal? AnnualAmount { get; set; }

  // Hourly
  public decimal? HourlyRate { get; set; }
  public decimal? DefaultHoursPerWeek { get; set; }
  public PayPeriod? Frequency { get; set; }

  // Variable
  public decimal? MonthlyAmount { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }

  public ICollection<PayPeriodEntry> PayPeriodEntries { get; set; } = [];

  public decimal MonthlyGross => PayType switch
  {
    PayType.Salary => (AnnualAmount ?? 0m) / 12m,
    PayType.Variable => MonthlyAmount ?? 0m,
    PayType.Hourly => ComputeHourlyMonthlyGross(),
    _ => 0m
  };

  private decimal ComputeHourlyMonthlyGross()
  {
    var periodsPerYear = Frequency == PayPeriod.Weekly ? 52m : 26m;
    var periodWeeks = Frequency == PayPeriod.Weekly ? 1m : 2m;
    var defaultPeriodHours = (DefaultHoursPerWeek ?? 0m) * periodWeeks;
    var rate = HourlyRate ?? 0m;

    var latest = PayPeriodEntries
      .OrderByDescending(p => p.PeriodStartDate)
      .FirstOrDefault();

    var periodGross = latest is null
      ? rate * defaultPeriodHours
      : rate * (latest.HoursWorked ?? defaultPeriodHours) + rate * latest.OvertimeMultiplier * latest.OvertimeHours;

    return periodGross * periodsPerYear / 12m;
  }
}

public enum PayType { Salary, Hourly, Variable }
public enum PayPeriod { Weekly, BiWeekly }
