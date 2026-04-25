using EcoRoot.Application.Interfaces;
using EcoRoot.Domain.Entitites;
using EcoRoot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoRoot.Infrastructure.Repositories
{
    public class ActivityLogRepository : Repository<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(EcoRootDbContext context) : base(context) { }

        public async Task<IEnumerable<ActivityLog>> GetAllWithDetailsAsync() =>
            await _context.ActivityLogs
                .Include(a => a.Crop)
                .Include(a => a.Student)
                .OrderByDescending(a => a.ActivityDate)
                .ToListAsync();

        public async Task<IEnumerable<ActivityLog>> GetByCropIdAsync(int cropId) =>
            await _context.ActivityLogs
                .Include(a => a.Crop)
                .Include(a => a.Student)
                .Where(a => a.CropId == cropId)
                .ToListAsync();

        public async Task<IEnumerable<ActivityLog>> GetByStudentIdAsync(int studentId) =>
            await _context.ActivityLogs
                .Include(a => a.Crop)
                .Include(a => a.Student)
                .Where(a => a.StudentId == studentId)
                .ToListAsync();
    }
}
