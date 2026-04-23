// src/FTBackend.Infrastructure/Repositories/TransactionRepository.cs
using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using FTBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FTBackend.Infrastructure.Repositories;

public class TransactionRepository(AppDbContext context) : ITransactionRepository
{
    public async Task<IEnumerable<Transaction>> GetByUserIdAsync(string userId) =>
        await context.Transactions
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

    public async Task<Transaction?> GetByIdAsync(Guid id, string userId) =>
        await context.Transactions
            .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        context.Transactions.Add(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction> UpdateAsync(Transaction transaction)
    {
        transaction.UpdatedAt = DateTime.UtcNow;
        context.Transactions.Update(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task DeleteAsync(Guid id, string userId)
    {
        var transaction = await GetByIdAsync(id, userId);
        if (transaction is not null)
        {
            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();
        }
    }
}
