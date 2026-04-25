using EcoRoot.Application.DTOs;
using EcoRoot.Application.Interfaces;
using EcoRoot.Application.Services.Interfaces;
using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Services
{
    public class CropService : ICropService
    {
        private readonly ICropRepository _repository;

        public CropService(ICropRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CropResponseDto>> GetAllAsync()
        {
            var crops = await _repository.GetAllAsync();
            return crops.Select(MapToResponse);
        }

        public async Task<CropResponseDto?> GetByIdAsync(int id)
        {
            var crop = await _repository.GetByIdAsync(id);
            return crop is null ? null : MapToResponse(crop);
        }

        public async Task<IEnumerable<CropResponseDto>> GetByPlotIdAsync(int plotId)
        {
            var crops = await _repository.GetByPlotIdAsync(plotId);
            return crops.Select(MapToResponse);
        }

        public async Task<CropResponseDto> CreateAsync(CropCreateDto dto)
        {
            var crop = new Crop
            {
                Name = dto.Name,
                Type = dto.Type,
                PlantingDate = dto.PlantingDate,
                EstimatedHarvestDate = dto.EstimatedHarvestDate,
                Status = dto.Status,
                PlotId = dto.PlotId
            };
            var created = await _repository.AddAsync(crop);
            return MapToResponse(created);
        }

        public async Task<CropResponseDto?> UpdateAsync(int id, CropUpdateDto dto)
        {
            var crop = await _repository.GetByIdAsync(id);
            if (crop is null) return null;

            crop.Name = dto.Name;
            crop.Type = dto.Type;
            crop.PlantingDate = dto.PlantingDate;
            crop.EstimatedHarvestDate = dto.EstimatedHarvestDate;
            crop.Status = dto.Status;
            crop.PlotId = dto.PlotId;

            await _repository.UpdateAsync(crop);
            return MapToResponse(crop);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var crop = await _repository.GetByIdAsync(id);
            if (crop is null) return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        private static CropResponseDto MapToResponse(Crop c) => new()
        {
            Id = c.Id,
            Name = c.Name,
            Type = c.Type,
            PlantingDate = c.PlantingDate,
            EstimatedHarvestDate = c.EstimatedHarvestDate,
            Status = c.Status,
            PlotId = c.PlotId,
            PlotName = c.Plot?.Name,
            CreatedAt = c.CreatedAt
        };
    }
}
