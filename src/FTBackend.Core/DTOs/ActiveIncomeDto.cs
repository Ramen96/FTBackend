namespace FTBackend.Core.DTOs;

public record ActiveIncomeDto(Guid Id, decimal Amount);
public record UpsertActiveIncomeRequest(decimal Amount);
