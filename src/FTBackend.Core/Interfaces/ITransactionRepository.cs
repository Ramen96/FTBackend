// src/FTBackend.Core/Interfaces/ITransactionRepository.cs
using FTBackend.Core.Entities;

namespace FTBackend.Core.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetByUserIdAsync(string userId);
    Task<Transaction?> GetByIdAsync(Guid id, string userId);
    Task<Transaction> CreateAsync(Transaction transaction);
    Task<Transaction> UpdateAsync(Transaction transaction);
    Task DeleteAsync(Guid id, string userId);
}
