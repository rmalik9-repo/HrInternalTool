using BCrypt.Net;
using HrInternalTool.Domain.Entities;
using HrInternalTool.Domain.Interfaces;
using HrInternalTool.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HrInternalTool.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HrDataDBContext _context;
        public UserRepository(HrDataDBContext context)
        {
            _context = context;
        }
        public async Task<UsersEntity?> AuthenticateAsync(UsersEntity user)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            string getUserHashPassword = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            if (getUser == null || BCrypt.Net.BCrypt.Verify(getUser.PasswordHash, getUserHashPassword))
                return null;

            return user;
        }
        public async Task<UsersEntity> RegisterAsync(UsersEntity users)
        {
            var user = new UsersEntity
            {
                Username = users.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(users.PasswordHash),
                Role = users.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
