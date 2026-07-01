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
public class LiabilitiesController(ILiabilityRepository repo) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException();

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await repo.GetByUserIdAsync(UserId));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var liability = await repo.GetByIdAsync(id, UserId);
        return liability is null ? NotFound() : Ok(liability);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLiabilityRequest request)
    {
        var liability = new Liability
        {
            UserId = UserId,
            Name = request.Name,
            Category = request.Category,
            Balance = request.Balance,
            Payment = request.Payment,
            Rate = request.Rate
        };

        var created = await repo.CreateAsync(liability);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLiabilityRequest request)
    {
        var liability = await repo.GetByIdAsync(id, UserId);
        if (liability is null) return NotFound();

        if (request.Name is not null) liability.Name = request.Name;
        if (request.Category.HasValue) liability.Category = request.Category.Value;
        if (request.Balance.HasValue) liability.Balance = request.Balance.Value;
        if (request.Payment.HasValue) liability.Payment = request.Payment.Value;
        if (request.Rate.HasValue) liability.Rate = request.Rate.Value;

        var updated = await repo.UpdateAsync(liability);
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var liability = await repo.GetByIdAsync(id, UserId);
        if (liability is null) return NotFound();

        await repo.DeleteAsync(id, UserId);
        return NoContent();
    }
}
