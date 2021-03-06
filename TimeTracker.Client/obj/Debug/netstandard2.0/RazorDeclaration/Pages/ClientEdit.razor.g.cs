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
#line 3 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\ClientEdit.razor"
using TimeTracker.Client.Models;

#line default
#line hidden
#line 4 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\ClientEdit.razor"
using TimeTracker.Client.Services;

#line default
#line hidden
#line 5 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\ClientEdit.razor"
           [Authorize]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/clients/{id:long}/edit")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/clients/add")]
    public partial class ClientEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 36 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\ClientEdit.razor"
       
    [Parameter] public long Id { get; set; }
    private ClientInputModel client = new ClientInputModel();
    private string errorMessage;

    protected override async Task OnInitializedAsync()
    {
        if (Id > 0)
        {
            await LoadClient();
        }
    }

    private async Task LoadClient()
    {
        var url = $"clients/{Id}";
        var model = await ApiService.GetAsync<ClientModel>(url);

        client = new ClientInputModel
        {
            Name = model.Name
        };
    }

    private async Task SaveClient()
    {
        bool success;

        if (Id > 0)
        {
            success = await ApiService.UpdateAsync<ClientInputModel>($"clients/{Id}", client);
        }
        else
        {
            success = await ApiService.CreateAsync<ClientInputModel>("clients", client);
        }

        if (success)
        {
            NavigationManager.NavigateTo("/clients");
        }
        else
        {
            errorMessage = "Error saving client";
        }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ApiService ApiService { get; set; }
    }
}
#pragma warning restore 1591
