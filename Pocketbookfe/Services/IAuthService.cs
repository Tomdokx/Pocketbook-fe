using pocketbookfe.Authentication;
using Pocketbookfe.Authentication;

namespace Pocketbookfe.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(TokenRequest model);

        Task<bool> IsUserLogged();

        Task<bool> LogOut();
    }
}
