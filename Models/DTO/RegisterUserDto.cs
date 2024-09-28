namespace hotel_management_API.Models.DTO
{
    public class RegisterUserDto
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int RoleId { get; set; }
        public int UserType { get; set; }
    }
}
