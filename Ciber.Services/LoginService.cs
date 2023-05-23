using Ciber.Infrastructure.EF;
using Ciber.Infrastructure.Helpers;
using Ciber.Infrastructure.Infrastructure.EF;
using Ciber.Models.Entities;
using Ciber.Models.Request;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ciber.Services
{
    public interface ILoginService
    {
        Task<User> Login(LoginRequest request);
    }
    public class LoginService : ILoginService
    {
        private readonly CiberDbContext _context;

        public LoginService(
            CiberDbContext context)
        {
            _context = context;
        }

        public async Task<User> Login(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(
                u => u.UserName == request.Username);

            if (user == null || !new PasswordHasher().VerifyPassword(user.Password, request.Password))
            {
                return null;
            }

            return user;
        }
    }
}
