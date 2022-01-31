#nullable enable

using System;

string? uri = null;

while (uri == null)
{
    Console.Write("Enter website URI without slash at the end and without tenant: ");

    uri = Console.ReadLine();
}

string? bearerToken = null;

while (bearerToken == null)
{
    Console.Write("Enter a valid OAuth bearer token: ");

    bearerToken = Console.ReadLine();
}

Console.WriteLine("Trying to set locale name to en-US...");

var screen = await new SoapLoginService().LoginAsync(uri, bearerToken);

string? scenarioName = null;

while (scenarioName == null)
{
    Console.Write("Enter a valid import scenario name for GetScenario call: ");

    scenarioName = Console.ReadLine();
}

await screen.GetScenarioAsync(scenarioName);