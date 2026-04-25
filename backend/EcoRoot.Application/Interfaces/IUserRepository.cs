using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<bool> ExistsAsync(string username);
        Task<User> AddAsync(User user);
    }
}
