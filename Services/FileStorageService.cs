using Microsoft.Extensions.Logging;
using NetwiseCatFactApp.Models;

namespace NetwiseCatFactApp.Services;

public class FileStorageService : IFileStorageService
{
    private const string FilePath = "cat_facts.txt";
    private readonly ILogger<FileStorageService> _logger;

    public FileStorageService(ILogger<FileStorageService> logger)
    {
        _logger = logger;
    }

    public async Task AppendFactAsync(CatFact fact, CancellationToken cancellationToken = default)
    {
        string logEntry = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC] {fact.Fact} (length: {fact.Length})";

        // File.AppendAllTextAsync automatycznie tworzy plik, jeśli ten nie istnieje
        await File.AppendAllTextAsync(FilePath, logEntry + Environment.NewLine, cancellationToken);
        _logger.LogInformation("Zapisano fakt do pliku {FilePath}", FilePath);
    }
}