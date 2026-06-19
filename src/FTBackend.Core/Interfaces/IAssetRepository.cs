using FTBackend.Core.Entities;

namespace FTBackend.Core.Interfaces;

public interface IAssetRepository
{
    Task<IEnumerable<Asset>> GetByUserIdAsync(string userId);
    Task<Asset?> GetByIdAsync(Guid id, string userId);
    Task<Asset> CreateAsync(Asset asset);
    Task<Asset> UpdateAsync(Asset asset);
    Task DeleteAsync(Guid id, string userId);
}
