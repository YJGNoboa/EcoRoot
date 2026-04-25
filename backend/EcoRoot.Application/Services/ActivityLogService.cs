using EcoRoot.Application.DTOs;
using EcoRoot.Application.Interfaces;
using EcoRoot.Application.Services.Interfaces;
using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IActivityLogRepository _repository;

        public ActivityLogService(IActivityLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ActivityLogResponseDto>> GetAllAsync()
        {
            var logs = await _repository.GetAllWithDetailsAsync();
            return logs.Select(MapToResponse);
        }

        public async Task<ActivityLogResponseDto?> GetByIdAsync(int id)
        {
            var log = await _repository.GetByIdAsync(id);
            return log is null ? null : MapToResponse(log);
        }

        public async Task<IEnumerable<ActivityLogResponseDto>> GetByCropIdAsync(int cropId)
        {
            var logs = await _repository.GetByCropIdAsync(cropId);
            return logs.Select(MapToResponse);
        }

        public async Task<IEnumerable<ActivityLogResponseDto>> GetByStudentIdAsync(int studentId)
        {
            var logs = await _repository.GetByStudentIdAsync(studentId);
            return logs.Select(MapToResponse);
        }

        public async Task<ActivityLogResponseDto> CreateAsync(ActivityLogCreateDto dto)
        {
            var log = new ActivityLog
            {
                Description = dto.Description,
                ActivityDate = dto.ActivityDate,
                ActivityType = dto.ActivityType,
                CropId = dto.CropId,
                StudentId = dto.StudentId
            };
            var created = await _repository.AddAsync(log);
            return MapToResponse(created);
        }

        public async Task<ActivityLogResponseDto?> UpdateAsync(int id, ActivityLogUpdateDto dto)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log is null) return null;

            log.Description = dto.Description;
            log.ActivityDate = dto.ActivityDate;
            log.ActivityType = dto.ActivityType;
            log.CropId = dto.CropId;
            log.StudentId = dto.StudentId;

            await _repository.UpdateAsync(log);
            return MapToResponse(log);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var log = await _repository.GetByIdAsync(id);
            if (log is null) return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        private static ActivityLogResponseDto MapToResponse(ActivityLog a) => new()
        {
            Id = a.Id,
            Description = a.Description,
            ActivityDate = a.ActivityDate,
            ActivityType = a.ActivityType,
            CropId = a.CropId,
            CropName = a.Crop?.Name,
            StudentId = a.StudentId,
            StudentName = a.Student is not null
                ? $"{a.Student.FirstName} {a.Student.LastName}"
                : null,
            CreatedAt = a.CreatedAt
        };
    }
}
