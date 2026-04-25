using EcoRoot.Application.Interfaces;
using EcoRoot.Domain.Entitites;
using EcoRoot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoRoot.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(EcoRootDbContext context) : base(context) { }

        public async Task<IEnumerable<Student>> GetByGradeAsync(string grade) =>
            await _context.Students
                .Where(s => s.Grade == grade)
                .ToListAsync();
    }
}
