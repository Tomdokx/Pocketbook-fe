using Microsoft.Extensions.Options;
using pocketbookfe.ApiClients.Interfaces;
using pocketbookfe.Models;
using Pocketbookfe.Shared;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace pocketbookfe.ApiClients
{
	public class TaskApiClient : ITaskApiClient
	{
		private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options;
        public TaskApiClient(HttpClient httpClient)
        {
			_httpClient = httpClient;
            options = new JsonSerializerOptions() { WriteIndented = true };
            options.Converters.Add(new DateFormatConverter("yyyy-MM-dd HH:mm:ss"));
        }

        public async Task<bool> AddNewTask(TaskModel task)
        {
			var result = await _httpClient.PostAsJsonAsync(ApiClient.ApiPrefix + $"/task/addTask", task, options);
			return result.IsSuccessStatusCode;
        }

        public async Task<bool> ChangeDone(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<bool>(ApiClient.ApiPrefix + $"/task/doneChange/" + id);
            return result;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var result = await _httpClient.DeleteAsync(ApiClient.ApiPrefix + $"/task/deleteTask/" + id);
            return result.IsSuccessStatusCode;
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
			var result = await _httpClient.GetFromJsonAsync<TaskModel>(ApiClient.ApiPrefix + $"/task/{id}", options);
			return result;
		}

        public async Task<List<TaskModel>> GetTasksByUserIdAsync(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<List<TaskModel>>(ApiClient.ApiPrefix + $"/task/byAuthor/{id}", options);
			return result;
		}

        public async Task<bool> UpdateTask(TaskModel task)
        {
            var result = await _httpClient.PutAsJsonAsync(ApiClient.ApiPrefix + $"/task/updateTask/" + task.Id, task, options);
            return result.IsSuccessStatusCode;
        }
    }
}
