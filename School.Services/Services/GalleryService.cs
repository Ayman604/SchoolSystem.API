using Microsoft.Extensions.Configuration;
using School.Domain.Contracts;
using School.Domain.Entities.ContentAndMedia;
using School.Domain.Enums;
using School.Services.Abstraction;
using School.Services.Specifications.GallerySpecifications;
using School.Shared;
using School.Shared.CommonResponses;
using School.Shared.DTOs.GalleryDTOs;

namespace School.Services.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public GalleryService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<Result<GalleryMediaDTO>> AddToGalleryAsync(CreateGalleryMediaDTO dto)
        {
            var repository = _unitOfWork.GetRepository<Media, int>();

            var media = new Media
            {
                FileName = dto.FileName,
                FilePath = dto.FilePath,
                AltText = dto.AltText,
                Type = dto.Type,
                Category = MediaCategory.Gallery,
                IsDeleted = false
            };

            await repository.AddAsync(media);
            await _unitOfWork.SAveChangesAsync();

            return Result<GalleryMediaDTO>.Ok(MapToDto(media));
        }

        public async Task<Result<bool>> DeleteFromGalleryAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Media, int>();

            var spec = new GalleryByIdSpecifications(id);

            var media = await repository.GetByIdAsync(spec);

            if (media is null)
                return Result<bool>.Fail(
                                    Error.NotFound("Gallery.NotFound", "Gallery media not found."));
            media.IsDeleted = true;

            await _unitOfWork.SAveChangesAsync();

            return Result<bool>.Ok(true);
        }

        public async Task<Result<GalleryPaginatedResultDTO>> GetAllGalleryMediaAsync(GalleryQueryParams queryParams)
        {
            var repository = _unitOfWork.GetRepository<Media, int>();

            var spec = new GallerySpecifications(queryParams);

            var countSpec = new GalleryCountSpecifications(queryParams);

            var mediaList = await repository.GetAllAsync(spec);

            var totalCount = await repository.CountAsync(countSpec);

            var result = new GalleryPaginatedResultDTO
            {
                Items = mediaList.Select(MapToDto).ToList(),

                PageIndex = queryParams.PageIndex,

                PageSize = queryParams.PageSize,

                TotalCount = totalCount,

                TotalPages = (int)Math.Ceiling(
                    (double)totalCount / queryParams.PageSize)
            };

            return Result<GalleryPaginatedResultDTO>.Ok(result);
        }

        public async Task<Result<GalleryMediaDTO>> GetGalleryMediaByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Media, int>();

            var spec = new GalleryByIdSpecifications(id);

            var media = await repository.GetByIdAsync(spec);

            if (media is null)
                return Result<GalleryMediaDTO>.Fail(
                    Error.NotFound("Gallery.NotFound", "Gallery media not found."));

            return Result<GalleryMediaDTO>.Ok(MapToDto(media));
        }

        private GalleryMediaDTO MapToDto(Media media)
        {
            var baseUrl = _configuration.GetSection("URLs")["BaseURL"];
            var fullPath = media.FilePath;
            if (!string.IsNullOrEmpty(media.FilePath))
            {
                if (!media.FilePath.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                    && !media.FilePath.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    fullPath = $"{baseUrl?.TrimEnd('/')}/{media.FilePath.TrimStart('/')}";
                }

            }
            return new GalleryMediaDTO
            {
                Id = media.Id,
                FileName = media.FileName,
                FilePath = media.FilePath,
                AltText = media.AltText,
                Type = media.Type
            };
        }
    }
}
