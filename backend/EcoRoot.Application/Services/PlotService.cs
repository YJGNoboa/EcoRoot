using EcoRoot.Application.DTOs;
using EcoRoot.Application.Interfaces;
using EcoRoot.Application.Services.Interfaces;
using EcoRoot.Domain.Entitites;

namespace EcoRoot.Application.Services
{
    public class PlotService : IPlotService
    {
        private readonly IPlotRepository _repository;

        public PlotService(IPlotRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlotResponseDto>> GetAllAsync()
        {
            var plots = await _repository.GetAllAsync();
            return plots.Select(MapToResponse);
        }

        public async Task<PlotResponseDto?> GetByIdAsync(int id)
        {
            var plot = await _repository.GetByIdAsync(id);
            return plot is null ? null : MapToResponse(plot);
        }

        public async Task<PlotResponseDto> CreateAsync(PlotCreateDto dto)
        {
            var plot = new Plot
            {
                Name = dto.Name,
                Area = dto.Area,
                Location = dto.Location,
                Description = dto.Description
            };
            var created = await _repository.AddAsync(plot);
            return MapToResponse(created);
        }

        public async Task<PlotResponseDto?> UpdateAsync(int id, PlotUpdateDto dto)
        {
            var plot = await _repository.GetByIdAsync(id);
            if (plot is null) return null;

            plot.Name = dto.Name;
            plot.Area = dto.Area;
            plot.Location = dto.Location;
            plot.Description = dto.Description;

            await _repository.UpdateAsync(plot);
            return MapToResponse(plot);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plot = await _repository.GetByIdAsync(id);
            if (plot is null) return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        private static PlotResponseDto MapToResponse(Plot p) => new()
        {
            Id = p.Id,
            Name = p.Name,
            Area = p.Area,
            Location = p.Location,
            Description = p.Description,
            CreatedAt = p.CreatedAt
        };
    }
}
