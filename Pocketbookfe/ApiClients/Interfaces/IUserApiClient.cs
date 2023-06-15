using pocketbookfe.Models;

namespace pocketbookfe.ApiClients.Interfaces
{
    public interface IUserApiClient
{

        Task<List<UserModel>> GetAllUsers();

        Task<List<UserModel>> GetUsers();

        Task<bool> UpdateUser(UserModel user);

        Task<bool> ChangePassword (UserModel user, string newPassword);

        Task<UserModel> GetUserById(int id);

        Task<bool> RegisterUser(UserModel user); 
}
}
