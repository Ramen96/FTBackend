using FTBackend.Core.DTOs;
using FTBackend.Core.Interfaces;
using FTBackend.Core.Mapping;
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
        Ok((await repo.GetByUserIdAsync(UserId)).Select(a => a.ToItemDto()));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var asset = await repo.GetByIdAsync(id, UserId);
        return asset is null ? NotFound() : Ok(asset.ToItemDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAssetRequest request)
    {
        var asset = request.ToEntity(UserId);
        var created = await repo.CreateAsync(asset);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToItemDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateAssetRequest request)
    {
        var existing = await repo.GetByIdAsync(id, UserId);
        if (existing is null) return NotFound();

        await repo.DeleteAsync(id, UserId);

        var replacement = request.ToEntity(UserId);
        replacement.Id = id;
        replacement.CreatedAt = existing.CreatedAt;

        var created = await repo.CreateAsync(replacement);
        return Ok(created.ToItemDto());
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
