using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using pocketbookfe.Authentication;
using Pocketbookfe.Authentication;
using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace Pocketbookfe.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly CustomAuthenticationStateProvider customAuthenticationStateProvider;
        private readonly ILocalStorageService localStorage;

        public AuthService(HttpClient httpClient,
            CustomAuthenticationStateProvider customAuthenticationStateProvider,
            ILocalStorageService localStorageService
            )
        {
            this.httpClient = httpClient;
            this.customAuthenticationStateProvider = customAuthenticationStateProvider;
            this.localStorage = localStorageService;
        }

        public async Task<bool> LoginAsync(TokenRequest model)
        {
            var response = await httpClient.PostAsJsonAsync("api/v1/authenticate", model);

            if (response.IsSuccessStatusCode)
            {
                var loginModel = await response.Content.ReadFromJsonAsync<LoginModel>();
                if (loginModel != null)
                {
                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, loginModel.LoggedInUser.Username),
                        }, "apiauth_type");
                    var user = new ClaimsPrincipal(identity);
                    var authState = new AuthenticationState(user);
                    customAuthenticationStateProvider.NotifyAuthenticationStateChanged(Task.FromResult(authState));
                    await localStorage.SetItemAsync("authToken", loginModel.Token);
                    await localStorage.SetItemAsync("loggedInUser", loginModel.LoggedInUser);

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{loginModel.Token}");
                }
                return true;
            }

            return false;
        }

        public async Task<bool> IsUserLogged()
        {
            return await localStorage.ContainKeyAsync("authToken");
        }

		public async Task<bool> LogOut()
		{
            if(await localStorage.ContainKeyAsync("authToken") == false)
            {
                return false;
            }

			await localStorage.RemoveItemAsync("authToken");
			await localStorage.RemoveItemAsync("loggedInUser");

			httpClient.DefaultRequestHeaders.Authorization = null;

			return true;
        }
	}
}
