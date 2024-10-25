using hotel_management_API.Models;
using hotel_management_API.Models.DTO;

namespace hotel_management_API.Service.Interface
{
    public interface IUserService
    {
        Task<User> RegisterUser(RegisterUserDto registerUserDto);
        Task<LoginResponseDto> LogIn(LogInDto logInDto);
    }
}
