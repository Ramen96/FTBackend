using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using FTBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FTBackend.Infrastructure.Repositories;

public class LiabilityRepository(AppDbContext context) : ILiabilityRepository
{
    public async Task<IEnumerable<Liability>> GetByUserIdAsync(string userId) =>
        await context.Liabilities
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

    public async Task<Liability?> GetByIdAsync(Guid id, string userId) =>
        await context.Liabilities
            .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

    public async Task<Liability> CreateAsync(Liability liability)
    {
        context.Liabilities.Add(liability);
        await context.SaveChangesAsync();
        return liability;
    }

    public async Task<Liability> UpdateAsync(Liability liability)
    {
        liability.UpdatedAt = DateTime.UtcNow;
        context.Liabilities.Update(liability);
        await context.SaveChangesAsync();
        return liability;
    }

    public async Task DeleteAsync(Guid id, string userId)
    {
        var liability = await GetByIdAsync(id, userId);
        if (liability is not null)
        {
            context.Liabilities.Remove(liability);
            await context.SaveChangesAsync();
        }
    }
}
