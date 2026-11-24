using Microsoft.AspNetCore.Mvc;
using School.Services.Abstraction;
using School.Shared.DTOs.PostDTOs;

namespace School.Presentation.Controllers
{
    public class NewsController : ApiBaseController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<PostPaginatedResultDTO>>
            GetAll([FromQuery] PostQueryParams queryParams)
        {
            var result = await _newsService.GetAllAsync(queryParams);

            return HandleResult<PostPaginatedResultDTO>(result);
        }

        // GET: api/News/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDTO>> GetById(int id)
        {
            var result = await _newsService.GetByIdAsync(id);

            return HandleResult<PostDTO>(result);
        }

        // POST: api/News
        [HttpPost]
        public async Task<ActionResult<PostDTO>> Add(
            CreatePostDTO dto)
        {
            var result = await _newsService.AddAsync(dto);

            return HandleResult<PostDTO>(result);
        }

        // PUT: api/News/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PostDTO>> Update(
            int id,
            UpdatePostDTO dto)
        {
            var result = await _newsService.UpdateAsync(id, dto);

            return HandleResult<PostDTO>(result);
        }

        // DELETE: api/News/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _newsService.DeleteAsync(id);

            return HandleResult(result);
        }
    }
}
