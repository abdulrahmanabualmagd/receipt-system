using Microsoft.AspNetCore.Mvc;
using MVC_Core.DTOs;
using MVC_Core.Models;

namespace MVC_Core.IRepositories
{
    public interface IAccountMangerService
    {
        Task<AccountMangerDto> RegisterAsync(RegisterCredentialsDTO registerCredentialsDTO);
        Task<AccountMangerDto> LoginAsync(LoginCredentialsDTO loginCredentialsDTO);
        Task<AccountMangerDto> GenerateJWT(User user);
    }
}
