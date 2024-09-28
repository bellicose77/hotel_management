using hotel_management_API.Models.DTO;
using hotel_management_API.Models;
using hotel_management_API.Service.Interface;
using System;

namespace hotel_management_API.Service.Service
{
    public class UserService:IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUser(RegisterUserDto userDto)
        {
            var hashedPassword = HashPassword(userDto.Password);
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = hashedPassword,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                RoleId = userDto.RoleId,
                UserType = userDto.UserType,
                Status = true,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private string HashPassword(string password)
        {
            // Use a proper hashing algorithm like BCrypt or PBKDF2.
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
