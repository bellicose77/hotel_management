using hotel_management_API.Models.DTO;
using hotel_management_API.Models;
using hotel_management_API.Service.Interface;
using System;
using Microsoft.EntityFrameworkCore;

namespace hotel_management_API.Service.Service
{
    public class UserService:IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> LogIn(LogInDto logInDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == logInDto.Email);

            if (user == null || !VerifyPassword(logInDto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }
            var token=GenerateJwtToken()
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
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Use BCrypt to verify the password against the stored hash
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}
