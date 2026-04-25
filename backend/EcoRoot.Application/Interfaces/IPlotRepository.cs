using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Interfaces
{
    public interface IPlotRepository : IRepository<Plot>
    {
        Task<IEnumerable<Plot>> GetAllWithCropsAsync();
    }
}
