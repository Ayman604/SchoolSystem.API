using Microsoft.AspNetCore.Mvc;
using School.Services.Abstraction;
using School.Shared.DTOs.PostDTOs;

namespace School.Presentation.Controllers
{
    public class OurPrideController : ApiBaseController
    {
        private readonly IOurPrideService _ourPrideService;

        public OurPrideController(IOurPrideService ourPrideService)
        {
            _ourPrideService = ourPrideService;
        }

        // GET: api/OurPride
        [HttpGet]
        public async Task<ActionResult<PostPaginatedResultDTO>>
            GetAll([FromQuery] PostQueryParams queryParams)
        {
            var result = await _ourPrideService.GetAllAsync(queryParams);

            return HandleResult<PostPaginatedResultDTO>(result);
        }

        // GET: api/OurPride/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDTO>> GetById(int id)
        {
            var result = await _ourPrideService.GetByIdAsync(id);

            return HandleResult<PostDTO>(result);
        }

        // POST: api/OurPride
        [HttpPost]
        public async Task<ActionResult<PostDTO>> Add(
            CreatePostDTO dto)
        {
            var result = await _ourPrideService.AddAsync(dto);

            return HandleResult<PostDTO>(result);
        }

        // PUT: api/OurPride/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PostDTO>> Update(
            int id,
            UpdatePostDTO dto)
        {
            var result = await _ourPrideService.UpdateAsync(id, dto);

            return HandleResult<PostDTO>(result);
        }

        // DELETE: api/OurPride/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ourPrideService.DeleteAsync(id);

            return HandleResult(result);
        }
    }
}
