namespace Server.Domain.Dtos;

public sealed record Result<T>(
    string? SuccessMessage,
    string? ErrorMessage,
    T? Data);