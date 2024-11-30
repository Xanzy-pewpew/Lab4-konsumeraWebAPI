using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab4
{
    public class GitHubProjektRepo
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }
        [JsonPropertyName("homepage")] public string Homepage { get; set; }
        [JsonPropertyName("watchers")] public int Watchers { get; set; }
        [JsonPropertyName("pushed_at")] public string PushedAt { get; set; }
    }
    public class ZipCodeInfo
    {
        [JsonPropertyName("places")] public List<Place> Places { get; set; }
        [JsonPropertyName("post code")] public string PostCode { get; set; } //Visning av postnummer
    }
    public class Place
    {
        [JsonPropertyName("place name")] public string Places { get; set; }
        [JsonPropertyName("state")] public string State { get; set; }
        [JsonPropertyName("latitude")]  public string Latitude { get; set; }
        [JsonPropertyName("longitude")]  public string Longitude { get; set; }
    }
}
