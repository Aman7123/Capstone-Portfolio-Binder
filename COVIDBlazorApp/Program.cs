using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorApp1.Services;
using Syncfusion.Blazor;
namespace BlazorApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Register Syncfusion license 
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQ5NjYwQDMxMzgyZTMzMmUzME0vT0hZYUVqMUd5ZXRjelVVbXdlTGF1SFZwOWZPMGxla3JmZlBJRmpsUHc9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            //builder.Services.AddScoped(sp => httpClient);            
            builder.Services.AddSingleton<ICOVIDDataService,COVIDDataService>(ds => new COVIDDataService(httpClient, builder.Configuration));
            builder.Services.AddSyncfusionBlazor(); //add sync fusion service
            await builder.Build().RunAsync();
        }
    }
}
