using EcoRoot.Application.DTOs;
using EcoRoot.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoRoot.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/plots")]
    public class PlotsController : ControllerBase
    {
        private readonly IPlotService _service;

        public PlotsController(IPlotService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlotResponseDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlotResponseDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null) return NotFound(new { message = $"Plot {id} not found." });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PlotResponseDto>> Create([FromBody] PlotCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PlotResponseDto>> Update(int id, [FromBody] PlotUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result is null) return NotFound(new { message = $"Plot {id} not found." });
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = $"Plot {id} not found." });
            return NoContent();
        }
    }
}
