using EcoRoot.Application.DTOs;

namespace EcoRoot.Application.Services.Interfaces
{
    public interface IPlotService
    {
        Task<IEnumerable<PlotResponseDto>> GetAllAsync();
        Task<PlotResponseDto?> GetByIdAsync(int id);
        Task<PlotResponseDto> CreateAsync(PlotCreateDto dto);
        Task<PlotResponseDto?> UpdateAsync(int id, PlotUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
