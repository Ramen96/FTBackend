// src/FTBackend.Core/Interfaces/IAccountRepository.cs
using FTBackend.Core.Entities;

namespace FTBackend.Core.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetByUserIdAsync(string userId);
    Task<Account?> GetByIdAsync(Guid id, string userId);
    Task<Account> CreateAsync(Account account);
    Task DeleteAsync(Guid id, string userId);
}
