using EcoRoot.Application.DTOs;
using EcoRoot.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoRoot.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/activity-logs")]
    public class ActivityLogsController : ControllerBase
    {
        private readonly IActivityLogService _service;

        public ActivityLogsController(IActivityLogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityLogResponseDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActivityLogResponseDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null) return NotFound(new { message = $"Activity log {id} not found." });
            return Ok(result);
        }

        [HttpGet("crop/{cropId:int}")]
        public async Task<ActionResult<IEnumerable<ActivityLogResponseDto>>> GetByCrop(int cropId)
        {
            var result = await _service.GetByCropIdAsync(cropId);
            return Ok(result);
        }

        [HttpGet("student/{studentId:int}")]
        public async Task<ActionResult<IEnumerable<ActivityLogResponseDto>>> GetByStudent(int studentId)
        {
            var result = await _service.GetByStudentIdAsync(studentId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ActivityLogResponseDto>> Create([FromBody] ActivityLogCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ActivityLogResponseDto>> Update(int id, [FromBody] ActivityLogUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result is null) return NotFound(new { message = $"Activity log {id} not found." });
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = $"Activity log {id} not found." });
            return NoContent();
        }
    }
}
