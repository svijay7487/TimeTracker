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
#line 3 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\ProjectEdit.razor"
using TimeTracker.Client.Models;

#line default
#line hidden
#line 4 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\ProjectEdit.razor"
using TimeTracker.Client.Services;

#line default
#line hidden
#line 5 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\ProjectEdit.razor"
           [Authorize]

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/projects/{id:long}/edit")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/projects/add")]
    public partial class ProjectEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 47 "D:\Repos\TimeTracker\TimeTracker.Client\Pages\ProjectEdit.razor"
       
    [Parameter] public long Id { get; set; }
    private string clientId = string.Empty;
    private Lookup[] clients = new Lookup[] {};
    private ProjectInputModel project = new ProjectInputModel();
    private string errorMessage;

    protected override async Task OnInitializedAsync()
    {
        await LoadClients();

        if (Id > 0)
        {
            await LoadProject();
        }
    }

    private async Task LoadClients()
    {
        var clientsUrl = $"clients?page=1&size={int.MaxValue}";
        var clientsList = await ApiService.GetAsync<PagedList<ClientModel>>(clientsUrl);
        clients = clientsList.Items.Select(x => new Lookup(x.Name, x.Id.ToString())).ToArray();
    }

    private async Task LoadProject()
    {
        var url = $"projects/{Id}";
        var model = await ApiService.GetAsync<ProjectModel>(url);

        project = new ProjectInputModel
        {
            Name = model.Name,
            ClientId = model.ClientId
        };

        clientId = model.ClientId.ToString();
    }

    private async Task SaveProject()
    {
        bool success;
        project.ClientId = long.Parse(clientId);

        if (Id > 0)
        {
            success = await ApiService.UpdateAsync<ProjectInputModel>($"projects/{Id}", project);
        }
        else
        {
            success = await ApiService.CreateAsync<ProjectInputModel>("projects", project);
        }

        if (success)
        {
            NavigationManager.NavigateTo("/projects");
        }
        else
        {
            errorMessage = "Error saving project";
        }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ApiService ApiService { get; set; }
    }
}
#pragma warning restore 1591
