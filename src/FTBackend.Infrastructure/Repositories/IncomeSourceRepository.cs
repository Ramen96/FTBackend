using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using FTBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FTBackend.Infrastructure.Repositories;

public class IncomeSourceRepository(AppDbContext context) : IIncomeSourceRepository
{
  public async Task<IEnumerable<IncomeSource>> GetByUserIdAsync(string userId) =>
    await context.IncomeSources
      .Include(i => i.PayPeriodEntries)
      .Where(t => t.UserId == userId)
      .OrderByDescending(t => t.CreatedAt)
      .ToListAsync();

  public async Task<IncomeSource?> GetByIdAsync(Guid id, string userId) =>
      await context.IncomeSources
        .Include(i => i.PayPeriodEntries)
        .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

  public async Task<IncomeSource> CreateAsync(IncomeSource incomeSource)
  {
    context.IncomeSources.Add(incomeSource);
    await context.SaveChangesAsync();
    return incomeSource;
  }

  public async Task<IncomeSource> UpdateAsync(IncomeSource incomeSource)
  {
    incomeSource.UpdatedAt = DateTime.UtcNow;
    context.IncomeSources.Update(incomeSource);
    await context.SaveChangesAsync();
    return incomeSource;
  }

  public async Task DeleteAsync(Guid id, string userId)
  {
    var incomeSource = await GetByIdAsync(id, userId);
    if (incomeSource is not null)
    {
      context.IncomeSources.Remove(incomeSource);
      await context.SaveChangesAsync();
    }
  }
}
