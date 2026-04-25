using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Interfaces
{
    public interface IActivityLogRepository : IRepository<ActivityLog>
    {
        Task<IEnumerable<ActivityLog>> GetByCropIdAsync(int cropId);
        Task<IEnumerable<ActivityLog>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<ActivityLog>> GetAllWithDetailsAsync();
    }
}
