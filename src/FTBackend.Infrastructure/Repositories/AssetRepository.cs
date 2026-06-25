using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using FTBackend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FTBackend.Infrastructure.Repositories;

public class AssetRepository(AppDbContext context) : IAssetRepository
{
    public async Task<IEnumerable<Asset>> GetByUserIdAsync(string userId) =>
        await context.Assets
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

    public async Task<Asset?> GetByIdAsync(Guid id, string userId) =>
        await context.Assets
            .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

    public async Task<Asset> CreateAsync(Asset asset)
    {
        context.Assets.Add(asset);
        await context.SaveChangesAsync();
        return asset;
    }

    public async Task<Asset> UpdateAsync(Asset asset)
    {
        asset.UpdatedAt = DateTime.UtcNow;
        context.Assets.Update(asset);
        await context.SaveChangesAsync();
        return asset;
    }

    public async Task DeleteAsync(Guid id, string userId)
    {
        var asset = await GetByIdAsync(id, userId);
        if (asset is not null)
        {
            context.Assets.Remove(asset);
            await context.SaveChangesAsync();
        }
    }
}
