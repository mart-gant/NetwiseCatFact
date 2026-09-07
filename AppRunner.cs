using Microsoft.Extensions.Logging;
using NetwiseCatFactApp.Services;

namespace NetwiseCatFactApp;

public class AppRunner
{
    private readonly ICatFactService _catFactService;
    private readonly IFileStorageService _fileStorageService;
    private readonly ILogger<AppRunner> _logger;

    public AppRunner(
        ICatFactService catFactService,
        IFileStorageService fileStorageService,
        ILogger<AppRunner> logger)
    {
        _catFactService = catFactService;
        _fileStorageService = fileStorageService;
        _logger = logger;
    }

    public async Task RunAsync()
    {
        _logger.LogInformation("Rozpoczynanie zapytania do endpointu...");

        var fact = await _catFactService.GetRandomFactAsync();
        if (fact is not null)
        {
            await _fileStorageService.AppendFactAsync(fact);
            Console.WriteLine($"\nOtrzymany fakt: {fact.Fact}\n");
        }
    }
}