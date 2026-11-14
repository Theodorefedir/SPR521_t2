using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPR521_t2.BLL.Dtos.SushiType;
using SPR521_t2.DAL.Entities;
using SPR521_t2.DAL.Repositories;

namespace SPR521_t2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SushiTypesController : ControllerBase
{
    private readonly ISushiTypeRepository _repository;
    private readonly IMapper _mapper;

    public SushiTypesController(
        ISushiTypeRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SushiTypeResponseDto>>> GetAll()
    {
        var sushiTypes = await _repository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<SushiTypeResponseDto>>(sushiTypes);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SushiTypeResponseDto>> GetById(int id)
    {
        var sushiType = await _repository.GetByIdAsync(id);

        if (sushiType is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SushiTypeResponseDto>(sushiType));
    }

    [HttpPost]
    public async Task<ActionResult<SushiTypeResponseDto>> Create(
        [FromBody] CreateSushiTypeDto dto)
    {
        var sushiType = _mapper.Map<SushiType>(dto);
        var created = await _repository.CreateAsync(sushiType);
        var result = _mapper.Map<SushiTypeResponseDto>(created);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<SushiTypeResponseDto>> Update(
        int id,
        [FromBody] UpdateSushiTypeDto dto)
    {
        var sushiType = _mapper.Map<SushiType>(dto);
        var updated = await _repository.UpdateAsync(id, sushiType);

        if (updated is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SushiTypeResponseDto>(updated));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
