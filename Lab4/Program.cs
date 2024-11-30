using Lab4;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient(); //Github
    static async Task Main(string[] args)
    {
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Lab4", "1.0")); //API krav (Github)
        await GetDotNetRepositories(); //Hämtning av repositories, Github
        await GetZipCodeInfo(); //Hämtning av repositories, Zippopotam
    }
    private static async Task GetDotNetRepositories()
    {
        var url = "https://api.github.com/orgs/dotnet/repos";
        var response = await client.GetStringAsync(url);
        var repositories = JsonSerializer.Deserialize<List<GitHubProjektRepo>>(response);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Repositories under .Net Foundation:");
        Console.ResetColor();
        foreach (var repo in repositories)
        {
            Console.WriteLine($"\nName: {repo.Name}"
                + $"\nHomepage: {repo.Homepage}"
                + $"\nGitHub: {repo.HtmlUrl}"
                + $"\nDescription: {repo.Description}"
                + $"\nWatchers: {repo.Watchers}"
                + $"\nLast push: {repo.PushedAt}\n");
        }
    }
    private static async Task GetZipCodeInfo()
    {
        var url = "https://api.zippopotam.us/us/07645";
        var response = await client.GetStringAsync(url);
        var zipCodeInfo = JsonSerializer.Deserialize<ZipCodeInfo>(response);
        if (zipCodeInfo != null && zipCodeInfo.Places.Count > 0)
        {
            var place = zipCodeInfo.Places[0];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Here is the extra detail:"); //Grön text för de önskade extra utskrivt från Zippopotam
            Console.ResetColor();
            Console.WriteLine($"ZIP Code: {zipCodeInfo.PostCode}"
                + $"\nPlace: {place.Places}"
                + $"\nState: {place.State}"
                + $"\nLatitude: {place.Latitude}"
                + $"\nLongitude: {place.Longitude}");
        }
        else { Console.WriteLine("No data found for the ZIP code."); }
    }
}
