// src/FTBackend.Infrastructure/Repositories/AccountRepository.cs
using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using FTBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FTBackend.Infrastructure.Repositories;

public class AccountRepository(AppDbContext context) : IAccountRepository
{
    public async Task<IEnumerable<Account>> GetByUserIdAsync(string userId) =>
        await context.Accounts
            .Where(a => a.UserId == userId)
            .Include(a => a.Transactions)
            .ToListAsync();

    public async Task<Account?> GetByIdAsync(Guid id, string userId) =>
        await context.Accounts
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

    public async Task<Account> CreateAsync(Account account)
    {
        context.Accounts.Add(account);
        await context.SaveChangesAsync();
        return account;
    }

    public async Task DeleteAsync(Guid id, string userId)
    {
        var account = await GetByIdAsync(id, userId);
        if (account is not null)
        {
            context.Accounts.Remove(account);
            await context.SaveChangesAsync();
        }
    }
}
