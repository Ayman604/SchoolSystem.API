using Microsoft.AspNetCore.Mvc;
using School.Services.Abstraction;
using School.Shared;
using School.Shared.DTOs.GalleryDTOs;

namespace School.Presentation.Controllers
{
    public class GalleryController : ApiBaseController
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        // GET: api/Gallery
        [HttpGet]
        public async Task<ActionResult<GalleryPaginatedResultDTO>>
            GetAllGalleryMedia(
                [FromQuery] GalleryQueryParams queryParams)
        {
            var result = await _galleryService
                .GetAllGalleryMediaAsync(queryParams);

            return HandleResult<GalleryPaginatedResultDTO>(result);
        }

        // GET: api/Gallery/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GalleryMediaDTO>>
            GetGalleryMediaById(int id)
        {
            var result = await _galleryService
                .GetGalleryMediaByIdAsync(id);

            return HandleResult<GalleryMediaDTO>(result);
        }

        // POST: api/Gallery
        [HttpPost]
        public async Task<ActionResult<GalleryMediaDTO>>
            AddToGallery(CreateGalleryMediaDTO dto)
        {
            var result = await _galleryService
                .AddToGalleryAsync(dto);

            return HandleResult<GalleryMediaDTO>(result);
        }

        // DELETE: api/Gallery/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>>
            DeleteFromGallery(int id)
        {
            var result = await _galleryService
                .DeleteFromGalleryAsync(id);

            return HandleResult<bool>(result);
        }
    }
}
