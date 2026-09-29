using FTBackend.Core.DTOs;
using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using FTBackend.Core.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FTBackend.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class IncomeSourcesController(IIncomeSourceRepository repo) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException();

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok((await repo.GetByUserIdAsync(UserId)).Select(i => i.ToDto()));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var incomeSource = await repo.GetByIdAsync(id, UserId);
        return incomeSource is null ? NotFound() : Ok(incomeSource.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateIncomeSourceRequest request)
    {
        var error = ValidateRequest(request);
        if (error is not null) return BadRequest(new { message = error });

        var incomeSource = request.ToEntity(UserId);
        var created = await repo.CreateAsync(incomeSource);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateIncomeSourceRequest request)
    {
        var error = ValidateRequest(request);
        if (error is not null) return BadRequest(new { message = error });

        var existing = await repo.GetByIdAsync(id, UserId);
        if (existing is null) return NotFound();

        existing.Name = request.Name;
        existing.PayType = request.PayType;
        existing.TaxRate = request.TaxRate;
        existing.AnnualAmount = request.AnnualAmount;
        existing.HourlyRate = request.HourlyRate;
        existing.DefaultHoursPerWeek = request.DefaultHoursPerWeek;
        existing.Frequency = request.Frequency;
        existing.MonthlyAmount = request.MonthlyAmount;

        var updated = await repo.UpdateAsync(existing);
        return Ok(updated.ToDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var incomeSource = await repo.GetByIdAsync(id, UserId);
        if (incomeSource is null) return NotFound();

        await repo.DeleteAsync(id, UserId);
        return NoContent();
    }

    // TODO (you write this): validate that each PayType has its required
    // fields present, using a switch expression with `when` guard clauses.
    // Return null if valid, or a message describing what's missing.
    private static string? ValidateRequest(CreateIncomeSourceRequest request)
    {
        throw new NotImplementedException();
    }
}
