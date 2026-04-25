using EcoRoot.Application.DTOs;
using EcoRoot.Application.Interfaces;
using EcoRoot.Application.Services.Interfaces;
using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(MapToResponse);
        }

        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            return student is null ? null : MapToResponse(student);
        }

        public async Task<StudentResponseDto> CreateAsync(StudentCreateDto dto)
        {
            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Grade = dto.Grade,
                Email = dto.Email
            };
            var created = await _repository.AddAsync(student);
            return MapToResponse(created);
        }

        public async Task<StudentResponseDto?> UpdateAsync(int id, StudentUpdateDto dto)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student is null) return null;

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Grade = dto.Grade;
            student.Email = dto.Email;

            await _repository.UpdateAsync(student);
            return MapToResponse(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student is null) return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        private static StudentResponseDto MapToResponse(Student s) => new()
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Grade = s.Grade,
            Email = s.Email,
            CreatedAt = s.CreatedAt
        };
    }
}
