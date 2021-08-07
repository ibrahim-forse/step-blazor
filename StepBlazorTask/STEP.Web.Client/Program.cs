using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using STEP.DataAccess.Interfaces;
using STEP.Services.DataMock;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace STEP.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            var invoicesService = await MockInvoicesService.GetService("http://localhost:1638/invoices");
            builder.Services.AddScoped<IInvoicesService>(options =>
            {
                return invoicesService;
            });
            var billingService = await MockBillingService.GetService("http://localhost:1638/billing");
            builder.Services.AddScoped<IBillingService>(options =>
            {
                return billingService;
            });
            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
    }
}
