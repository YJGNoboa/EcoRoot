using EcoRoot.Application.Interfaces;
using EcoRoot.Domain.Entitites;
using EcoRoot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoRoot.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcoRootDbContext _context;

        public UserRepository(EcoRootDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        public async Task<bool> ExistsAsync(string username) =>
            await _context.Users.AnyAsync(u => u.Username == username);

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
