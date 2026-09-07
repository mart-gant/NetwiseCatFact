using System.Text.Json;
using Microsoft.Extensions.Logging;
using NetwiseCatFactApp.Models;

namespace NetwiseCatFactApp.Services;

public class CatFactService : ICatFactService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CatFactService> _logger;

    public CatFactService(HttpClient httpClient, ILogger<CatFactService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<CatFact?> GetRandomFactAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var responseStream = await _httpClient.GetStreamAsync("fact", cancellationToken);
            return await JsonSerializer.DeserializeAsync<CatFact>(responseStream, cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Błąd podczas pobierania faktu o kotach.");
            throw;
        }
    }
}