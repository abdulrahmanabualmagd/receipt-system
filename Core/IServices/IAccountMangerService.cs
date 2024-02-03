using Core.DTOs;
using Core.Models;

namespace Core.AccountManger
{
    public interface IAccountMangerService
    {
        Task<AccountMangerDto> RegisterAsync(RegisterCredentialsDTO registerCredentialsDTO);
        Task<AccountMangerDto> LoginAsync(LoginCredentialsDTO loginCredentialsDTO);
        Task<AccountMangerDto> GenerateJWT(ApplicationUser user);
    }
}
