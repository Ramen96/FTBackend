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
public class ActiveIncomeController(IActiveIncomeRepository repo) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException();

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var activeIncome = await repo.GetByUserIdAsync(UserId);
        return activeIncome is null ? NotFound() : Ok(new ActiveIncomeDto(activeIncome.Id, activeIncome.Amount));
    }

    [HttpPost]
    public async Task<IActionResult> Upsert([FromBody] UpsertActiveIncomeRequest request)
    {
        var activeIncome = new ActiveIncome
        {
            UserId = UserId,
            Amount = request.Amount
        };
        var result = await repo.UpsertAsync(activeIncome);
        return Ok(new ActiveIncomeDto(result.Id, result.Amount));
    }
}
