using School.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace School.Domain.Entities.ContentAndMedia
{
    public class Post : BaseEntity<int>
    {

        [StringLength(250, MinimumLength = 5)]
        public string Title { get; set; } = string.Empty;

        [RegularExpression(@"^[a-z0-9-]+$", ErrorMessage = "استخدم أحرف صغيرة وأرقام وشرطات فقط")]
        public string Slug { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
        public string? Excerpt { get; set; }

        public PostType Type { get; set; }

        [Range(0, int.MaxValue)]
        public int DisplayOrder { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAtUtc { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAtUtc { get; set; } // Soft delete

        #region Navigation properties
        public ICollection<PostMedia?> MediaAttachments { get; set; } = new HashSet<PostMedia?>();
        #endregion

    }
}

