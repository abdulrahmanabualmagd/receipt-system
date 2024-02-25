using Core.DTOs;
using Core.Entities.UserIdentity;

namespace Core.AccountManger
{
    public interface IAccountMangerService
    {
        Task<bool> RegisterAsync(RegisterCredentialsDTO registerCredentialsDTO);
        Task<bool> RegisterCustomerAsync(ApplicationUser user);
        Task<bool> LoginAsync(LoginCredentialsDTO loginCredentialsDTO);
        Task LogoutAsync();
        Task<AccountMangerDto> GenerateJWT(ApplicationUser user);
    }
}
