using School.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace School.Domain.Entities.ContentAndMedia
{
    public class PostMedia
    {

        public int PostId { get; set; }
        public int MediaId { get; set; }
        public MediaRole MediaRole { get; set; }

        [Range(0, int.MaxValue)]
        public int DisplayOrder { get; set; }

        #region Navigation properties
        public Post RelatedPost { get; set; } = default!;
        public Media RelatedMedia { get; set; } = default!;
        #endregion
    }
}
