using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetwiseCatFactApp.Services;

namespace NetwiseCatFactApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Typed HttpClient – rejestruje ICatFactService z gotowym adresem bazowym
                services.AddHttpClient<ICatFactService, CatFactService>(client =>
                {
                    client.BaseAddress = new Uri("https://catfact.ninja/");
                    client.Timeout = TimeSpan.FromSeconds(10);
                });

                // Rejestracja w kontenerze Dependency Injection
                services.AddSingleton<IFileStorageService, FileStorageService>();
                services.AddTransient<AppRunner>();
            })
            .Build();

        using var scope = host.Services.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<AppRunner>();
        await runner.RunAsync();
    }
}