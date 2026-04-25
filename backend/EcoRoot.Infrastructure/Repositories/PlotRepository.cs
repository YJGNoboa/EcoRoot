using EcoRoot.Application.Interfaces;
using EcoRoot.Domain.Entitites;
using EcoRoot.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoRoot.Infrastructure.Repositories
{
    public class PlotRepository : Repository<Plot>, IPlotRepository
    {
        public PlotRepository(EcoRootDbContext context) : base(context) { }

        public async Task<IEnumerable<Plot>> GetAllWithCropsAsync() =>
            await _context.Plots
                .Include(p => p.Crops)
                .ToListAsync();
    }
}
