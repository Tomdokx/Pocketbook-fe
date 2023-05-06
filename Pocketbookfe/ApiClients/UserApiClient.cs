using pocketbookfe.ApiClients.Interfaces;
using pocketbookfe.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using static MudBlazor.Colors;

namespace pocketbookfe.ApiClients
{
	public class UserApiClient : IUserApiClient
	{
		private readonly HttpClient _httpClient;

		public UserApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
        }
		public async Task<List<UserModel>> GetUsers()
		{
			var result = await _httpClient.GetFromJsonAsync<List<UserModel>>(ApiClient.ApiPrefix + "/users");
			return result;
		}
		public async Task<List<UserModel>> GetAllUsers()
		{
			var result = await _httpClient.GetFromJsonAsync<List<UserModel>>(ApiClient.ApiPrefix + "/users/all");
			return result;
		}
		public async Task<UserModel> GetUserById(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<UserModel>(ApiClient.ApiPrefix + $"/user/{id}");
			return result;
		}

        public async Task<string> Test()
        {
            var x = await _httpClient.GetAsync("api/v1/users");
			return await x.Content.ReadAsStringAsync();
        }
    }
}
