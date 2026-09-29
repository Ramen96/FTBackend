using FTBackend.Core.Entities;

namespace FTBackend.Core.Interfaces;

public interface IIncomeSourceRepository
{

  Task<IEnumerable<IncomeSource>> GetByUserIdAsync(string userId);
  Task<IncomeSource?> GetByIdAsync(Guid id, string userId);
  Task<IncomeSource> CreateAsync(IncomeSource incomeSource);
  Task<IncomeSource> UpdateAsync(IncomeSource incomeSource);
  Task DeleteAsync(Guid id, string userId);
}
