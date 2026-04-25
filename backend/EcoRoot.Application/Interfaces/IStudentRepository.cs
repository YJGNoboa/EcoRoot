using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetByGradeAsync(string grade);
    }
}
