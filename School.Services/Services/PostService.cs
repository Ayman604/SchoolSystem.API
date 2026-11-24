using School.Domain.Contracts;
using School.Domain.Entities.ContentAndMedia;
using School.Domain.Enums;
using School.Services.Abstraction;
using School.Services.Specifications.PostSpecifications;
using School.Shared.CommonResponses;
using School.Shared.DTOs.PostDTOs;

namespace School.Services.Services
{
    public abstract class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected abstract PostType ContentType { get; }

        protected PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ADD
        public async Task<Result<PostDTO>> AddAsync(CreatePostDTO dto)
        {
            var postRepository = _unitOfWork.GetRepository<Post, int>();

            var attachments = await GetAttachmentsAsync(dto.MediaIds);

            if (attachments is null)
            {
                return Result<PostDTO>.Fail(
                    Error.NotFound(
                        "Post.MediaNotFound",
                        "One or more media files were not found."));
            }

            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                Type = ContentType,
                IsPublished = dto.IsPublished,
                UpdatedAtUtc = DateTime.UtcNow,
                MediaAttachments = attachments
            };

            await postRepository.AddAsync(post);

            await _unitOfWork.SAveChangesAsync();

            return Result<PostDTO>.Ok(MapToDto(post));
        }

        // UPDATE
        public async Task<Result<PostDTO>> UpdateAsync(
            int id,
            UpdatePostDTO dto)
        {
            var postRepository = _unitOfWork.GetRepository<Post, int>();

            var spec = new PostByIdSpecifications(id, ContentType);

            var post = await postRepository.GetByIdAsync(spec);

            if (post is null)
            {
                return Result<PostDTO>.Fail(
                    Error.NotFound(
                        "Post.NotFound",
                        "Post not found."));
            }

            var attachments = await GetAttachmentsAsync(dto.MediaIds);

            if (attachments is null)
            {
                return Result<PostDTO>.Fail(
                    Error.NotFound(
                        "Post.MediaNotFound",
                        "One or more media files were not found."));
            }

            post.Title = dto.Title;
            post.Content = dto.Content;
            post.IsPublished = dto.IsPublished;
            post.UpdatedAtUtc = DateTime.UtcNow;

            // Replace old attachments with the new attachments
            post.MediaAttachments.Clear();

            foreach (var attachment in attachments)
            {
                attachment.PostId = post.Id;
                post.MediaAttachments.Add(attachment);
            }

            await _unitOfWork.SAveChangesAsync();

            return Result<PostDTO>.Ok(MapToDto(post));
        }

        // DELETE - Soft Delete is not available on Post currently
        // So this implementation performs hard deletion only if desired.
        public async Task<Result> DeleteAsync(int id)
        {
            var postRepository = _unitOfWork.GetRepository<Post, int>();

            var spec = new PostByIdSpecifications(id, ContentType);

            var post = await postRepository.GetByIdAsync(spec);

            if (post is null)
            {
                return Result.Fail(
                    Error.NotFound(
                        "Post.NotFound",
                        "Post not found."));
            }

            postRepository.Delete(post);

            await _unitOfWork.SAveChangesAsync();

            return Result.OK();
        }

        // GET BY ID
        public async Task<Result<PostDTO>> GetByIdAsync(int id)
        {
            var postRepository = _unitOfWork.GetRepository<Post, int>();

            var spec = new PostByIdSpecifications(id, ContentType);

            var post = await postRepository.GetByIdAsync(spec);

            if (post is null)
            {
                return Result<PostDTO>.Fail(
                    Error.NotFound(
                        "Post.NotFound",
                        "Post not found."));
            }

            return Result<PostDTO>.Ok(MapToDto(post));
        }

        // GET ALL
        public async Task<Result<PostPaginatedResultDTO>> GetAllAsync(
            PostQueryParams queryParams)
        {
            var postRepository = _unitOfWork.GetRepository<Post, int>();

            var spec = new PostSpecifications(ContentType, queryParams);

            var countSpec = new PostCountSpecifications(
                ContentType,
                queryParams);

            var posts = await postRepository.GetAllAsync(spec);

            var totalCount = await postRepository.CountAsync(countSpec);

            var result = new PostPaginatedResultDTO
            {
                Items = posts.Select(MapToDto).ToList(),

                PageIndex = queryParams.PageIndex,

                PageSize = queryParams.PageSize,

                TotalCount = totalCount,

                TotalPages = (int)Math.Ceiling(
                    (double)totalCount / queryParams.PageSize)
            };

            return Result<PostPaginatedResultDTO>.Ok(result);
        }

        // Validate and build PostMedia collection
        private async Task<List<PostMedia>?> GetAttachmentsAsync(
            IEnumerable<int>? mediaIds)
        {
            var ids = mediaIds?.Distinct().ToList() ?? [];

            if (ids.Count == 0)
                return [];

            var mediaRepository = _unitOfWork.GetRepository<Media, int>();

            var spec = new MediaByIdsSpecifications(ids);

            var mediaList = (await mediaRepository.GetAllAsync(spec))
                .ToList();

            if (mediaList.Count != ids.Count)
                return null;

            return mediaList.Select(media => new PostMedia
            {
                MediaId = media.Id,
                Media = media
            }).ToList();
        }

        // Mapping
        private static PostDTO MapToDto(Post post)
        {
            return new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Type = post.Type,
                IsPublished = post.IsPublished,
                UpdatedAtUtc = post.UpdatedAtUtc,

                MediaAttachments = post.MediaAttachments
                    .Where(attachment =>
                        attachment.Media is not null &&
                        !attachment.Media.IsDeleted)
                    .Select(attachment => new PostMediaDTO
                    {
                        MediaId = attachment.Media.Id,
                        FileName = attachment.Media.FileName,
                        FilePath = attachment.Media.FilePath,
                        AltText = attachment.Media.AltText,
                        Type = attachment.Media.Type
                    })
                    .ToList()
            };
        }
    }
}
