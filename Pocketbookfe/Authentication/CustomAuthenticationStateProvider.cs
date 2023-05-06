using Microsoft.AspNetCore.Components.Authorization;
using pocketbookfe.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;

namespace Pocketbookfe.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly HttpClient httpClient;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            this.localStorage = localStorage;
            this.httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var user = await localStorage.GetItemAsync<UserModel>("loggedInUser");

            var identity = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, user.Username),
            
        }, "apiauth_type");

            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }
        public void NotifyAuthenticationStateChanged(Task<AuthenticationState> state)
        {
            // Call the base class method to notify the authentication state has changed with the new state
            base.NotifyAuthenticationStateChanged(state);
        }
    }
}
