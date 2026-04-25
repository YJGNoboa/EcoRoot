using EcoRoot.Application.Interfaces;
using EcoRoot.Domain.Entitites;
using EcoRoot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoRoot.Infrastructure.Repositories
{
    public class CropRepository : Repository<Crop>, ICropRepository
    {
        public CropRepository(EcoRootDbContext context) : base(context) { }

        public async Task<IEnumerable<Crop>> GetByPlotIdAsync(int plotId) =>
            await _context.Crops
                .Include(c => c.Plot)
                .Where(c => c.PlotId == plotId)
                .ToListAsync();

        public async Task<Crop?> GetWithActivityLogsAsync(int id) =>
            await _context.Crops
                .Include(c => c.Plot)
                .Include(c => c.ActivityLogs)
                    .ThenInclude(a => a.Student)
                .FirstOrDefaultAsync(c => c.Id == id);

        public new async Task<IEnumerable<Crop>> GetAllAsync() =>
            await _context.Crops
                .Include(c => c.Plot)
                .ToListAsync();
    }
}
