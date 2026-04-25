using EcoRoot.Application.DTOs;
using EcoRoot.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoRoot.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/crops")]
    public class CropsController : ControllerBase
    {
        private readonly ICropService _service;

        public CropsController(ICropService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CropResponseDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CropResponseDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null) return NotFound(new { message = $"Crop {id} not found." });
            return Ok(result);
        }

        [HttpGet("plot/{plotId:int}")]
        public async Task<ActionResult<IEnumerable<CropResponseDto>>> GetByPlot(int plotId)
        {
            var result = await _service.GetByPlotIdAsync(plotId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CropResponseDto>> Create([FromBody] CropCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CropResponseDto>> Update(int id, [FromBody] CropUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result is null) return NotFound(new { message = $"Crop {id} not found." });
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = $"Crop {id} not found." });
            return NoContent();
        }
    }
}
