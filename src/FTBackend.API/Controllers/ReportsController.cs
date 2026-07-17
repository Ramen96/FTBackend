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
public class ReportController(IReportService reportService) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException();

    [HttpGet("{type}")]
    public async Task<IActionResult> GetReport(string type)
    {
        return type switch
        {
            "income"      => Ok(await reportService.GetIncomeReportAsync(UserId)),
            "expenses"    => Ok(await reportService.GetExpensesReportAsync(UserId)),
            "assets"      => Ok(await reportService.GetAssetsReportAsync(UserId)),
            "liabilities" => Ok(await reportService.GetLiabilitiesReportAsync(UserId)),
            _             => NotFound()
        };
    }
}
