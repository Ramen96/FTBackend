using FTBackend.Core.DTOs;
using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FTBackend.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssetsController(IAssetRepository repo) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException();

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await repo.GetByUserIdAsync(UserId));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var asset = await repo.GetByIdAsync(id, UserId);
        return asset is null ? NotFound() : Ok(asset);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAssetRequest request)
    {
        var asset = new Asset
        {
            UserId = UserId,
            Name = request.Name,
            Category = request.Category,
            Quantity = request.Quantity,
            Value = request.Value,
            Rate = request.Rate
        };

        var created = await repo.CreateAsync(asset);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAssetRequest request)
    {
        var asset = await repo.GetByIdAsync(id, UserId);
        if (asset is null) return NotFound();

        if (request.Name is not null) asset.Name = request.Name;
        if (request.Category.HasValue) asset.Category = request.Category.Value;
        if (request.Quantity.HasValue) asset.Quantity = request.Quantity.Value;
        if (request.Value.HasValue) asset.Value = request.Value.Value;
        if (request.Rate.HasValue) asset.Rate = request.Rate.Value;

        var updated = await repo.UpdateAsync(asset);
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var asset = await repo.GetByIdAsync(id, UserId);
        if (asset is null) return NotFound();

        await repo.DeleteAsync(id, UserId);
        return NoContent();
    }
}
