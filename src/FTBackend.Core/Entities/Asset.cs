namespace FTBackend.Core.Entities;

public abstract class Asset
{
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public abstract decimal MonthlyIncome { get; }
        public abstract decimal? UnrealizedGrowth { get; }
}
