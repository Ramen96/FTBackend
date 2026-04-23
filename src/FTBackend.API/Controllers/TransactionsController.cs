// src/FTBackend.API/Controllers/TransactionsController.cs
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
public class TransactionsController(ITransactionRepository repo) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException();

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await repo.GetByUserIdAsync(UserId));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var transaction = await repo.GetByIdAsync(id, UserId);
        return transaction is null ? NotFound() : Ok(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransactionRequest request)
    {
        var transaction = new Transaction
        {
            UserId = UserId,
            Amount = request.Amount,
            Description = request.Description,
            Category = request.Category,
            Type = request.Type
        };

        var created = await repo.CreateAsync(transaction);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTransactionRequest request)
    {
        var transaction = await repo.GetByIdAsync(id, UserId);
        if (transaction is null) return NotFound();

        if (request.Amount.HasValue) transaction.Amount = request.Amount.Value;
        if (request.Description is not null) transaction.Description = request.Description;
        if (request.Category is not null) transaction.Category = request.Category;
        if (request.Type.HasValue) transaction.Type = request.Type.Value;

        var updated = await repo.UpdateAsync(transaction);
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var transaction = await repo.GetByIdAsync(id, UserId);
        if (transaction is null) return NotFound();

        await repo.DeleteAsync(id, UserId);
        return NoContent();
    }
}
