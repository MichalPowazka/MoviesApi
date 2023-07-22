using MoviesApi.Models;

namespace MoviesApi.Services
{
    public interface IAccountService
    {
        string GenerateJwt(LoginDto loginDto);
        void RegisterUser(RegisterUserDto userDto);
    }
}