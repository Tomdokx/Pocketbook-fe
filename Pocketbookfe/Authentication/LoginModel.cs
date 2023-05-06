using pocketbookfe.Models;

namespace Pocketbookfe.Authentication
{
    public class LoginModel
    {
        public string Token { get; set; }
        public UserModel LoggedInUser { get; set; }
    }
}
