using System.Threading.Tasks;
using Mavanmanen.StreamDeckSharp;
using Mavanmanen.StreamDeckSharp.Attributes;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace com.mavanmanen.streamdeckrest
{
    [StreamDeckPlugin("REST", "Images/icon", "mavanmanen", "Perform REST API calls", "1.0", category: "REST", categoryIcon: "Images/icon")]
    [StreamDeckMinimumOsVersion("10", "10.11")]
    public class Program : StreamDeckPlugin
    {
        public static async Task Main(string[] args)
        {
            var client = new StreamDeckClient(args);
            await client.RunAsync();
        }

        public override void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IRestClient, RestClient>();
        }
    }
}
