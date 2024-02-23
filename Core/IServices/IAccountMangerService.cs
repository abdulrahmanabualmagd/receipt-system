using Core.DTOs;
using Core.Entities.UserIdentity;

namespace Core.AccountManger
{
    public interface IAccountMangerService
    {
        Task<AccountMangerDto> RegisterAsync(RegisterCredentialsDTO registerCredentialsDTO);
        Task<AccountMangerDto> LoginAsync(LoginCredentialsDTO loginCredentialsDTO);
        Task LogoutAsync();
        Task<AccountMangerDto> GenerateJWT(ApplicationUser user);
    }
}
