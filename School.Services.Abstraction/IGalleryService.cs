using School.Shared;
using School.Shared.CommonResponses;
using School.Shared.DTOs.GalleryDTOs;

namespace School.Services.Abstraction
{
    public interface IGalleryService
    {

        Task<Result<GalleryMediaDTO>> AddToGalleryAsync(CreateGalleryMediaDTO dto);
        Task<Result<bool>> DeleteFromGalleryAsync(int id);
        Task<Result<GalleryPaginatedResultDTO>> GetAllGalleryMediaAsync(GalleryQueryParams queryParams);
        Task<Result<GalleryMediaDTO>> GetGalleryMediaByIdAsync(int id);



    }
}
