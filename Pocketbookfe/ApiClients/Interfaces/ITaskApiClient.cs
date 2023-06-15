using MudBlazor;
using pocketbookfe.Models;

namespace pocketbookfe.ApiClients.Interfaces
{
    public interface ITaskApiClient
{
        Task<bool> AddNewTask(TaskModel task);
        Task<bool> DeleteTask(int id);
        Task<TaskModel> GetTaskById(int id);
        Task<bool> UpdateTask(TaskModel task);
        Task<List<TaskModel>> GetTasksByUserIdAsync(int id);

        Task<bool> ChangeDone(int id);
        
}
}
