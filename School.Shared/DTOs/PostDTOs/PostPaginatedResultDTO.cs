namespace School.Shared.DTOs.PostDTOs
{
    public record PostPaginatedResultDTO
    {
        public IReadOnlyList<PostDTO> Items { get; set; } = [];

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
    }
}
