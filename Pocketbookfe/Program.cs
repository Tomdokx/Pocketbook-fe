using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Pocketbookfe;
using pocketbookfe.ApiClients;
using Pocketbookfe.Services;
using pocketbookfe.ApiClients.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Pocketbookfe.Authentication;
using Microsoft.AspNetCore.Authorization;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<MudBlazor.Services.IKeyInterceptorFactory, MudBlazor.Services.KeyInterceptorFactory>();
builder.Services.AddScoped<IScrollManager, ScrollManager>();
builder.Services.AddScoped<MudBlazor.IMudPopoverService, MudBlazor.MudPopoverService>();
builder.Services.AddMudServices();

builder.Services.AddScoped<IUserApiClient, UserApiClient>();
builder.Services.AddScoped<ITaskApiClient, TaskApiClient>();
builder.Services.AddScoped<INoteApiClient, NoteApiClient>();

builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s =>
    s.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddScoped<IAuthorizationPolicyProvider, DefaultAuthorizationPolicyProvider>();

builder.Services.AddSingleton<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IAuthorizationService, DefaultAuthorizationService>();

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(ApiClient.ApiBase) });

await builder.Build().RunAsync();
