using LittleLibraryAPI.Entities;
using LittleLibraryAPI.Models;

namespace LittleLibraryAPI.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);
    }
}
