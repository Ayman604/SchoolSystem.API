namespace School.Shared.DTOs.PostDTOs
{
    public class PostQueryParams
    {
        public string? Search { get; set; }

        public bool? IsPublished { get; set; }

        public PostSortingOptions Sort { get; set; }
            = PostSortingOptions.Newest;

        private int _pageIndex = 1;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value <= 0 ? 1 : value;
        }

        private const int DefaultPageSize = 10;
        private const int MaxPageSize = 30;

        private int _pageSize = DefaultPageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value <= 0
                ? DefaultPageSize
                : Math.Min(value, MaxPageSize);
        }
    }
}
