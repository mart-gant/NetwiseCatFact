using NetwiseCatFactApp.Models;

namespace NetwiseCatFactApp.Services;

public interface ICatFactService
{
    Task<CatFact?> GetRandomFactAsync(CancellationToken cancellationToken = default);
}