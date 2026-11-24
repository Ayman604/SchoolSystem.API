using School.Domain.Enums;

namespace School.Shared.DTOs.PostDTOs
{
    public record PostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public PostType Type { get; set; }

        public bool IsPublished { get; set; }

        public DateTime UpdatedAtUtc { get; set; }

        public IReadOnlyList<PostMediaDTO> MediaAttachments { get; set; }
            = [];
    }
}
