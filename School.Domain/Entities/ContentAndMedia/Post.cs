using School.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace School.Domain.Entities.ContentAndMedia
{
    public class Post : BaseEntity<int>
    {

        [StringLength(250, MinimumLength = 5)]
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public PostType Type { get; set; }

        [Range(0, int.MaxValue)]
        public bool IsPublished { get; set; }
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        #region Navigation properties
        public ICollection<PostMedia> MediaAttachments { get; set; } = new HashSet<PostMedia>();
        #endregion

    }
}

