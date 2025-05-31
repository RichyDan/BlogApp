using Microsoft.AspNetCore.Identity;
using API.DATA.Models.Request.Users;
using API.DATA.Models.Response;

namespace API.Services.IServices
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterRequest model);
        Task<IdentityResult> EditAccount(UserEditRequest model);
        Task<SignInResult> Login(LoginRequest model);
        Task<UserEditRequest> EditAccount(Guid id);
        Task RemoveAccount(Guid id);
        Task<List<User>> GetAccounts();
    }
}
