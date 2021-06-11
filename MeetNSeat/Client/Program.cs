using Blazored.SessionStorage;
using MeetNSeat.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MudBlazor;
using MudBlazor.Services;

namespace MeetNSeat.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                config.SnackbarConfiguration.PreventDuplicates = true;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddOidcAuthentication<RemoteAuthenticationState, CustomRemoteUserAccount>(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.DefaultScopes.Add("email");
                options.ProviderOptions.ResponseType = "code";
            }).AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomRemoteUserAccount, CustomUserClaimsPrincipal>();
            builder.Services.AddHttpClient("IP", (options) => {
                options.BaseAddress = new Uri("https://jsonip.com");
            });
            builder.Services.AddScoped<IApiClientService, ApiClientService>();
            await builder.Build().RunAsync();
        }
    }
}
