// src/FTBackend.API/Controllers/AccountsController.cs
using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FTBackend.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AccountsController(IAccountRepository repo) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException();

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await repo.GetByUserIdAsync(UserId));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var account = await repo.GetByIdAsync(id, UserId);
        return account is null ? NotFound() : Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
    {
        var account = new Account
        {
            UserId = UserId,
            Name = request.Name,
            Type = request.Type,
            Balance = request.Balance
        };

        var created = await repo.CreateAsync(account);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var account = await repo.GetByIdAsync(id, UserId);
        if (account is null) return NotFound();

        await repo.DeleteAsync(id, UserId);
        return NoContent();
    }
}

// Add this DTO to src/FTBackend.Core/DTOs/AccountDto.cs
public record CreateAccountRequest(
    string Name,
    AccountType Type,
    decimal Balance
);
