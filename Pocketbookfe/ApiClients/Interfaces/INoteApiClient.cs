using pocketbookfe.Models;

namespace pocketbookfe.ApiClients.Interfaces
{
    public interface INoteApiClient
{
        Task<bool> AddNewNoteToAssignment(int taskId, NoteModel note);
		Task<bool> AddNewNoteToOwner(int userId, NoteModel note);
		Task<bool> DeleteNote(int id);
        Task<NoteModel> GetNoteById(int id);
        Task<bool> UpdateNote(NoteModel note);
        Task<List<NoteModel>> GetNotesByUserIdAsync(int userId);
        Task<List<NoteModel>> GetNotesByTaskIdAsync(int taskId);
    }
}
