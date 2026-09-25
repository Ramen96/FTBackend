namespace FTBackend.Core.Entities;

public class PayPeriodEntry
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public Guid IncomeSourceId { get; set; }
  public DateTime PeriodStartDate { get; set; }
  public decimal? HoursWorked { get; set; }
  public decimal OvertimeHours { get; set; }
  public decimal OvertimeMultiplier { get; set; } = 1.5m;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
