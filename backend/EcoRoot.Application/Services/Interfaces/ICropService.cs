using EcoRoot.Application.DTOs;

namespace EcoRoot.Application.Services.Interfaces
{
    public interface ICropService
    {
        Task<IEnumerable<CropResponseDto>> GetAllAsync();
        Task<CropResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<CropResponseDto>> GetByPlotIdAsync(int plotId);
        Task<CropResponseDto> CreateAsync(CropCreateDto dto);
        Task<CropResponseDto?> UpdateAsync(int id, CropUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
