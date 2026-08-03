using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using FTBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FTBackend.Infrastructure.Repositories;

public class ActiveIncomeRepository(AppDbContext context) : IActiveIncomeRepository
{
    public async Task<ActiveIncome?> GetByUserIdAsync(string userId) =>
        await context.ActiveIncomes
            .FirstOrDefaultAsync(a => a.UserId == userId);

    public async Task<ActiveIncome> UpsertAsync(ActiveIncome activeIncome)
    {
        var existing = await GetByUserIdAsync(activeIncome.UserId);
        if (existing is null)
        {
            context.ActiveIncomes.Add(activeIncome);
        }
        else
        {
            existing.Amount = activeIncome.Amount;
            existing.UpdatedAt = DateTime.UtcNow;
            context.ActiveIncomes.Update(existing);
        }
        await context.SaveChangesAsync();
        return existing ?? activeIncome;
    }
}
