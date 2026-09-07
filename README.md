# Netwise Cat Facts

Console application created as a recruitment task for Netwise.

## Description

The application retrieves cat facts from the Cat Facts API:

https://catfact.ninja/fact

After each successful request, the received fact is appended
to a local `catfacts.txt` file as a new line.

## Technologies

- C#
- .NET
- Dependency Injection
- HttpClient
- IHttpClientFactory
- System.Text.Json
- async/await

## How to run

```bash
dotnet restore
dotnet run
