using System.ComponentModel.DataAnnotations;

namespace School.Shared.DTOs.PostDTOs
{
    public record UpdatePostDTO
    {
        [Required]
        [StringLength(250, MinimumLength = 5)]
        public string Title { get; set; } = default!;

        [Required]
        public string Content { get; set; } = default!;

        public bool IsPublished { get; set; }

        public List<int> MediaIds { get; set; } = [];
    }
}
