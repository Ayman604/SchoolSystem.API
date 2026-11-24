using School.Domain.Enums;

namespace School.Shared.DTOs.GalleryDTOs
{
    public record CreateGalleryMediaDTO
    {
        public string FileName { get; set; } = default!;

        public string FilePath { get; set; } = default!;

        public string AltText { get; set; } = default!;

        public MediaType Type { get; set; }
    }
}
