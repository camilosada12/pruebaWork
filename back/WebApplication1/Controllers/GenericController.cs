using Business.Enums;
using Business.Services;
using Entity.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity, TDto> : ControllerBase
        where TEntity : BaseModel
        where TDto : BaseDto
    {
        private readonly IBaseModelBusiness<TEntity, TDto> _service;

        public GenericController(IBaseModelBusiness<TEntity, TDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] TDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id, [FromQuery] DeleteMode mode = DeleteMode.fisico)
        {
            var result = await _service.DeleteAsync(id, mode);
            return result ? Ok() : NotFound();
        }

    }
}
