
using pocketbookfe.ApiClients.Interfaces;
using pocketbookfe.Models;
using Pocketbookfe.Pages.Tasks;
using Pocketbookfe.Shared;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace pocketbookfe.ApiClients
{
    public class NoteApiClient : INoteApiClient
{
		private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options;

        public NoteApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
            options = new JsonSerializerOptions() { WriteIndented = true };
            options.Converters.Add(new DateFormatConverter("yyyy-MM-dd HH:mm:ss"));
        }

		public async Task<bool> AddNewNoteToAssignment(int taskId, NoteModel note)
		{
			var result = await _httpClient.PostAsJsonAsync(ApiClient.ApiPrefix + $"/note/addNoteToAssignment/{taskId}", note, options);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> AddNewNoteToOwner(int userId, NoteModel note)
		{
			var result = await _httpClient.PostAsJsonAsync(ApiClient.ApiPrefix + $"/note/addNoteToOwner/{ userId}", note, options);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteNote(int id)
		{
			var result = await _httpClient.DeleteAsync(ApiClient.ApiPrefix + $"/note/deleteNote/{id}");
			return result.IsSuccessStatusCode;
		}

		public async Task<NoteModel> GetNoteById(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<NoteModel>(ApiClient.ApiPrefix + $"/note/{id}", options);
			return result;
		}

		public async Task<List<NoteModel>> GetNotesByTaskIdAsync(int taskId)
		{
			var result = await _httpClient.GetFromJsonAsync<List<NoteModel>>(ApiClient.ApiPrefix + $"/note/byAssignment/{taskId}", options);
			return result;
		}

		public async Task<List<NoteModel>> GetNotesByUserIdAsync(int userId)
		{
			var result = await _httpClient.GetFromJsonAsync<List<NoteModel>>(ApiClient.ApiPrefix + $"/note/byOwner/{userId}", options);
			return result;
		}

		public async Task<bool> UpdateNote(NoteModel note)
		{
			var result = await _httpClient.PutAsJsonAsync(ApiClient.ApiPrefix + $"/task/updateNote/" + note.Id, note, options);
			return result.IsSuccessStatusCode;
		}
	}
}
