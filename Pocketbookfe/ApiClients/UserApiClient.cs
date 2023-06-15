using pocketbookfe.ApiClients.Interfaces;
using pocketbookfe.Models;
using Pocketbookfe.Pages.Tasks;
using Pocketbookfe.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using static MudBlazor.Colors;

namespace pocketbookfe.ApiClients
{
	public class UserApiClient : IUserApiClient
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions options;
        public UserApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
            options = new JsonSerializerOptions() { WriteIndented = true, PropertyNameCaseInsensitive = true };
            options.Converters.Add(new DateFormatConverter("yyyy-MM-dd HH:mm:ss"));			
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

        public async Task<bool> RegisterUser(UserModel user)
        {
			var result = await _httpClient.PostAsJsonAsync(ApiClient.ApiPrefix + "/register", user, options);
			return result.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUser(UserModel user)
		{
			var result = await _httpClient.PutAsJsonAsync(ApiClient.ApiPrefix + $"/user/updateUser/{user.Id}", user, options);
			return result.IsSuccessStatusCode;
		}

        public async Task<bool> ChangePassword(UserModel user, string newPassword)
		{
			var result = await _httpClient.GetFromJsonAsync<bool>(ApiClient.ApiPrefix + $"/user/changePass/{user.Id}/{newPassword}");
			return result;
		}
    }
}
