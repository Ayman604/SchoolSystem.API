using School.Shared.CommonResponses;
using School.Shared.DTOs.PostDTOs;

namespace School.Services.Abstraction
{
    public interface IPostService
    {
        Task<Result<PostDTO>> AddAsync(CreatePostDTO dto);

        Task<Result<PostDTO>> UpdateAsync(
            int id,
            UpdatePostDTO dto);

        Task<Result> DeleteAsync(int id);

        Task<Result<PostDTO>> GetByIdAsync(int id);

        Task<Result<PostPaginatedResultDTO>> GetAllAsync(
            PostQueryParams queryParams);
    }
}
