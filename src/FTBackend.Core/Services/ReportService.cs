using FTBackend.Core.DTOs;
using FTBackend.Core.Entities;
using FTBackend.Core.Interfaces;

namespace FTBackend.Core.Services;

public class ReportService(
    ITransactionRepository transactionRepository,
    IAssetRepository assetRepository,
    ILiabilityRepository liabilityRepository
) : IReportService
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly IAssetRepository _assetRepository = assetRepository;
    private readonly ILiabilityRepository _liabilityRepository = liabilityRepository;

    public async Task<ReportDto<TransactionItemDto>> GetIncomeReportAsync(string userId)
    {
        var transactions = await _transactionRepository.GetByUserIdAsync(userId);
        var income = transactions.Where(t => t.Type == TransactionType.Income);
        var categories = income
            .GroupBy(t => t.Category)
            .Select(group => new ReportCategoryDto<TransactionItemDto>(
                group.Key,
                group.Select(t => new TransactionItemDto(
                    t.Id,
                    t.Category,
                    t.Description,
                    t.Amount
                ))
            ));
        var total = income.Sum(t => t.Amount);
        return new ReportDto<TransactionItemDto>(categories, total);
    }

    public async Task<ReportDto<TransactionItemDto>> GetExpensesReportAsync(string userId)
    {
        var transactions = await _transactionRepository.GetByUserIdAsync(userId);
        var expenses = transactions.Where(t => t.Type == TransactionType.Expense);
        var categories = expenses
            .GroupBy(t => t.Category)
            .Select(group => new ReportCategoryDto<TransactionItemDto>(
                group.Key,
                group.Select(t => new TransactionItemDto(
                    t.Id,
                    t.Category,
                    t.Description,
                    t.Amount
                ))
            ));
        var total = expenses.Sum(t => t.Amount);
        return new ReportDto<TransactionItemDto>(categories, total);
    }

    public async Task<ReportDto<AssetItemDto>> GetAssetsReportAsync(string userId)
    {
        var assets = await _assetRepository.GetByUserIdAsync(userId);
        var categories = assets
            .GroupBy(t => t.Category.ToString())
            .Select(group => new ReportCategoryDto<AssetItemDto>(
                group.Key,
                group.Select(t => new AssetItemDto(
                    t.Id,
                    t.Name,
                    t.Quantity,
                    t.Value,
                    t.Rate
                ))
            ));
        var total = assets.Sum(t => t.Value);
        return new ReportDto<AssetItemDto>(categories, total);
    }

    public async Task<ReportDto<LiabilityItemDto>> GetLiabilitiesReportAsync(string userId)
    {
        var liabilities = await _liabilityRepository.GetByUserIdAsync(userId);
        var categories = liabilities
            .GroupBy(t => t.Category.ToString())
            .Select(group => new ReportCategoryDto<LiabilityItemDto>(
                group.Key,
                group.Select(t => new LiabilityItemDto(
                    t.Id,
                    t.Name,
                    t.Balance,
                    t.Payment,
                    t.Rate
                ))
            ));
        var total = liabilities.Sum(t => t.Balance);
        return new ReportDto<LiabilityItemDto>(categories, total);
    }
}
