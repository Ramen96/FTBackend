public class Liability
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public LiabilityCategory Category { get; set; }
    public decimal Balance { get; set; }
    public decimal Payment { get; set; }
    public decimal Rate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public enum LiabilityCategory { CreditCards, AutoLoans, StudentLoans, RealEstate, BusinessLoans }
