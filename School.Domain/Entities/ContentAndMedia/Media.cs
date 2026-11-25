using School.Domain.Enums;

namespace School.Domain.Entities.ContentAndMedia
{
    public class Media : BaseEntity<int>
    {
        public string FileName { get; set; } = default!;
        public string FilePath { get; set; } = default!;
        public string AltText { get; set; } = default!;
        public MediaType Type { get; set; }
        public MediaCategory Category { get; set; }
        public bool IsDeleted { get; set; }


    }


}
