using NetwiseCatFactApp.Models;

namespace NetwiseCatFactApp.Services;

public interface IFileStorageService
{
    Task AppendFactAsync(CatFact fact, CancellationToken cancellationToken = default);
}