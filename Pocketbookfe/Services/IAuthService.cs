using pocketbookfe.Authentication;
using pocketbookfe.Models;
using Pocketbookfe.Authentication;

namespace Pocketbookfe.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(TokenRequest model);

        Task<bool> IsUserLogged();

        Task<bool> LogOut();

        Task<UserModel> LoggedUser();

        Task<bool> UpdateUser(UserModel user);
    }
}
