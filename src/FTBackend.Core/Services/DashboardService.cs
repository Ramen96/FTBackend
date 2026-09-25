using FTBackend.Core.DTOs;
using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;

namespace FTBackend.Core.Services;

public class DashboardService(
    ITransactionRepository transactionRepository,
    IAssetRepository assetRepository,
    ILiabilityRepository liabilityRepository,
    IIncomeSourceRepository incomeSourceRepository
) : IDashboardService
{
  private readonly ITransactionRepository _transactionRepository = transactionRepository;
  private readonly IAssetRepository _assetRepository = assetRepository;
  private readonly ILiabilityRepository _liabilityRepository = liabilityRepository;
  private readonly IIncomeSourceRepository _incomeSourceRepository = incomeSourceRepository;

  public async Task<DashboardDto> GetDashboardAsync(string userId)
  {
    var transactions = await _transactionRepository.GetByUserIdAsync(userId);
    var income = transactions.Where(t => t.Type == TransactionType.Income);
    var expenses = transactions.Where(t => t.Type == TransactionType.Expense);
    var assets = await _assetRepository.GetByUserIdAsync(userId);
    var liabilities = await _liabilityRepository.GetByUserIdAsync(userId);
    var incomeSources = await _incomeSourceRepository.GetByUserIdAsync(userId);
    var activeIncomeTotal = incomeSources.Sum(i => i.MonthlyGross);
    var passiveIncome = assets.Sum(a => a.MonthlyIncome);
    return new DashboardDto(
        income.Sum(t => t.Amount),
        expenses.Sum(t => t.Amount),
        assets.Sum(t => t.Value),
        liabilities.Sum(t => t.Balance),
        activeIncomeTotal,
        passiveIncome
    );
  }
}
