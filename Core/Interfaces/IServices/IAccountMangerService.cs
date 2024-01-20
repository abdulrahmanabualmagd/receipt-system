using Infrastructure.DTOs;
using Infrastructure.Models;


namespace Core.Interfaces.IServices
{
    public interface IAccountMangerService
    {
        Task<AccountMangerDto> RegisterAsync(RegisterCredentialsDTO registerCredentialsDTO);
        Task<AccountMangerDto> LoginAsync(LoginCredentialsDTO loginCredentialsDTO);
        Task<AccountMangerDto> GenerateJWT(User user);
    }
}
