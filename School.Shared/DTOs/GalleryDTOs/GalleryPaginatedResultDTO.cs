namespace School.Shared.DTOs.GalleryDTOs
{
    public record GalleryPaginatedResultDTO
    {
        public IReadOnlyList<GalleryMediaDTO> Items { get; set; }
            = [];

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
    }
}
