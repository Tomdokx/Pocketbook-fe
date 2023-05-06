using pocketbookfe.Models;

namespace pocketbookfe.ApiClients.Interfaces
{
    public interface IUserApiClient
{

        Task<string> Test();

        Task<List<UserModel>> GetAllUsers();

        Task<List<UserModel>> GetUsers();

        Task<UserModel> GetUserById(int id);
}
}
