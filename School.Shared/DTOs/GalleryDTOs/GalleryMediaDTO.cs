using School.Domain.Enums;

namespace School.Shared.DTOs.GalleryDTOs
{
    public record GalleryMediaDTO
    {
        public int Id { get; set; }

        public string FileName { get; set; } = default!;

        public string FilePath { get; set; } = default!;

        public string AltText { get; set; } = default!;

        public MediaType Type { get; set; }
    }
}
