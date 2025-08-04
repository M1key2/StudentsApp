using Microsoft.EntityFrameworkCore;
using StudentsApp.Data;
using StudentsApp.Models;

namespace StudentsApp.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Authenticate(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return null;

            bool valid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return valid ? user : null;
        }

        public async Task<User> Register(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
