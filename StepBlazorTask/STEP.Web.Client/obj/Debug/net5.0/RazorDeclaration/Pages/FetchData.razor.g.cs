// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace STEP.Web.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using STEP.Web.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using STEP.Web.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using STEP.Web.Client.Pages.MyApprovals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using STEP.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using STEP.DataAccess.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using STEP.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using STEP.Web.Client.Pages.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\_Imports.razor"
using STEP.Web.Client.Pages.Billing;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 37 "H:\Code\step-blazor\StepBlazorTask\STEP.Web.Client\Pages\FetchData.razor"
       
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
