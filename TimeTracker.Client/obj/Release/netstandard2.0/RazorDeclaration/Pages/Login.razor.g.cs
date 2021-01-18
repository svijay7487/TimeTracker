// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TimeTracker.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#line 3 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 4 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 5 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 6 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 7 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using TimeTracker.Client;

#line default
#line hidden
#line 8 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using TimeTracker.Client.Shared;

#line default
#line hidden
#line 9 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#line 10 "D:\Repos\TimeTracker\TimeTracker.Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#line 2 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\Login.razor"
using TimeTracker.Client.Models;

#line default
#line hidden
#line 3 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\Login.razor"
using TimeTracker.Client.Security;

#line default
#line hidden
#line 4 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\Login.razor"
using TimeTracker.Client.Services;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 29 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\Login.razor"
       
    string errorMessage;
    string userId = string.Empty;

    public Task LogInRegular()
    {
        return LogIn(false);
    }

    public Task LogInAdmin()
    {
        return LogIn(true);
    }

    private async Task LogIn(bool admin)
    {
        var url = Config.TokenUrl;
        if (admin)
        {
            url += "?admin=true";
        }

        errorMessage = string.Empty;

        try
        {
            var token = await Http.GetStringAsync(url);
            var user = await ApiService.GetAsync<UserModel>($"users/{userId}", token);

            await AuthStateProvider.SetTokenAndUserAsync(token, user);

            NavigationManager.NavigateTo("/");
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private TokenAuthenticationStateProvider AuthStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ApiService ApiService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
