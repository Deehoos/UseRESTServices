using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace UseRESTServices
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            List<GitHubRelease> list = new List<GitHubRelease>();
            list = GetDeserializedReleases("https://api.github.com/repos/restsharp/restsharp/releases");
            
            foreach (GitHubRelease release in list)
            {
                Console.WriteLine("Name: " + release.Name);
                Console.WriteLine("Published At: " + release.PublishedAt + "\n");
            }

            //Console.WriteLine(GetDeserializedReleases("https://api.github.com/repos/restsharp/restsharp/releases"));
        }

        public static string GetReleases(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute(new RestRequest());

            return response.Content;
        }

        public class GitHubRelease
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
            [JsonProperty(PropertyName = "published_at")]
            public string PublishedAt { get; set; }
        }

        public static List<GitHubRelease> GetDeserializedReleases(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute<List<GitHubRelease>>(new RestRequest());

            return response.Data;
        }
    }
}
