using hotel_management_API.Models.DTO;
using hotel_management_API.Models;
using hotel_management_API.Service.Interface;
using System;
using Microsoft.EntityFrameworkCore;
using hotel_management_API.Utility;
using Microsoft.IdentityModel.Tokens;

namespace hotel_management_API.Service.Service
{
    public class UserService:IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoginResponseDto> LogIn(LogInDto logInDto)
        {
            LoginResponseDto response = new LoginResponseDto();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == logInDto.Email);
       

            if (user == null || !VerifyPassword(logInDto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }
            TokenHelper tokenHelper = new TokenHelper();
            var token = tokenHelper.GenerateJwtToken(user);
            if (token == null)
            {
                throw new Exception("Failed to generate token.");
                
            }
            response = new LoginResponseDto
            {
                token = token.ToString(),
                Name = user.FirstName + " " + user.LastName,
                Role = user.Role,
            };
            return response;
        }

        public async Task<User> RegisterUser(RegisterUserDto userDto)
        {
            var hashedPassword = HashPassword(userDto.Password);
            var user = new User
            {
                Email = userDto.Email,
                PasswordHash = hashedPassword,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                Address = userDto.Address,
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
