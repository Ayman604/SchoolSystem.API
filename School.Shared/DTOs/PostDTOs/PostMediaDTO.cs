using School.Domain.Enums;

namespace School.Shared.DTOs.PostDTOs
{
    public record PostMediaDTO
    {
        public int MediaId { get; set; }

        public string FileName { get; set; } = default!;

        public string FilePath { get; set; } = default!;

        public string AltText { get; set; } = default!;

        public MediaType Type { get; set; }
    }
}
