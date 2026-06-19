using FTBackend.Core.Entities;

namespace FTBackend.Core.Interfaces;

public interface ILiabilityRepository
{
    Task<IEnumerable<Liability>> GetByUserIdAsync(string userId);
    Task<Liability?> GetByIdAsync(Guid id, string userId);
    Task<Liability> CreateAsync(Liability liability);
    Task<Liability> UpdateAsync(Liability liability);
    Task DeleteAsync(Guid id, string userId);
}
