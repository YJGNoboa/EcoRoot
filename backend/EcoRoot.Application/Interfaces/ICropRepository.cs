using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Interfaces
{
    public interface ICropRepository : IRepository<Crop>
    {
        Task<IEnumerable<Crop>> GetByPlotIdAsync(int plotId);
        Task<Crop?> GetWithActivityLogsAsync(int id);
    }
}
