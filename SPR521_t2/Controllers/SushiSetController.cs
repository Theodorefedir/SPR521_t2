using Microsoft.AspNetCore.Mvc;
using SPR521_t2.BLL.Dtos.SushiSet;
using SPR521_t2.DAL.Entities;
using SPR521_t2.DAL.Repositories;

namespace SPR521_t2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SushiSetController : ControllerBase
    {
        private readonly ISushiSetRepository _repository;

        public SushiSetController(ISushiSetRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sets = await _repository.GetAllAsync();

            var result = new List<SushiSetResponseDto>();
            foreach (var s in sets)
            {
                result.Add(new SushiSetResponseDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    Weight = s.Weight,
                    SushiTypeId = s.SushiTypeId
                });
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _repository.GetByIdAsync(id);
            if (s == null)
                return NotFound();

            var result = new SushiSetResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                Weight = s.Weight,
                SushiTypeId = s.SushiTypeId
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSushiSetDto dto)
        {
            var set = new SushiSet
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = "",
                Weight = dto.Weight,
                Order = 0,
                SushiTypeId = dto.SushiTypeId
            };

            await _repository.CreateAsync(set);
            return Ok(set.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSushiSetDto dto)
        {
            var set = new SushiSet
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price,
                Weight = dto.Weight,
                SushiTypeId = dto.SushiTypeId
            };

            var ok = await _repository.UpdateAsync(set);
            if (!ok)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _repository.DeleteAsync(id);
            if (!ok)
                return NotFound();

            return Ok();
        }
    }
}