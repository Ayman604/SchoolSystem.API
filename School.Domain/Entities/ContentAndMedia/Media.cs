using School.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace School.Domain.Entities.ContentAndMedia
{
    public class Media : BaseEntity<int>
    {
        public string FileName { get; set; } = default!;
        public string FilePath { get; set; } = default!;
        public string MimeType { get; set; } = default!;

        [Range(1, long.MaxValue)]
        public long FileSizeBytes { get; set; }
        public string AltText { get; set; } = default!;
        public MediaType Type { get; set; }
        public MediaCategory Category { get; set; }


        //[ForeignKey(nameof(UploadedByUser))]
        //public string UploadedByUserId { get; set; } = string.Empty;
        //public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAtUtc { get; set; } // Soft delete

        #region Navigation properties
        //  public ApplicationUser? UploadedByUser { get; set; } // ابقى زود ادمن يوزر
        public PostMedia? OwnerPost { get; set; }
        //  public ICollection<LessonMedia> Lessons { get; set; } = new List<LessonMedia>();
        #endregion
    }
}
