using Blazored.SessionStorage;
using MeetNSeat.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MeetNSeat.Client.Utils;

namespace MeetNSeat.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
            });
            builder.Services.AddHttpClient("IP", (options) => {
                options.BaseAddress = new Uri("https://jsonip.com");
            });
            builder.Services.AddHttpClient<FeedbackService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient<UserService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddScoped<IApiClientService, ApiClientService>();
            builder.Services.AddScoped<IUserUtils, UserUtils>();

            await builder.Build().RunAsync();
        }
    }
}
