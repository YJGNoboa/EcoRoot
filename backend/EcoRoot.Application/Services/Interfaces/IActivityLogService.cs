using EcoRoot.Application.DTOs;

namespace EcoRoot.Application.Services.Interfaces
{
    public interface IActivityLogService
    {
        Task<IEnumerable<ActivityLogResponseDto>> GetAllAsync();
        Task<ActivityLogResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<ActivityLogResponseDto>> GetByCropIdAsync(int cropId);
        Task<IEnumerable<ActivityLogResponseDto>> GetByStudentIdAsync(int studentId);
        Task<ActivityLogResponseDto> CreateAsync(ActivityLogCreateDto dto);
        Task<ActivityLogResponseDto?> UpdateAsync(int id, ActivityLogUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
