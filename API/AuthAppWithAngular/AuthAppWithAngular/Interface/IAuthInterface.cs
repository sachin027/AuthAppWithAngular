using AuthAppWithAngular.Helper;
using AuthAppWithAngular.Models;

namespace AuthAppWithAngular.Interface
{
    public interface IAuthInterface
    {
        Task<APIResponse> UserRegistration(UserRegister userRegister);
    }
}
