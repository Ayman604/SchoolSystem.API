using School.Domain.Entities.ContentAndMedia;
using School.Domain.Enums;

namespace School.Services.Specifications.GallerySpecifications
{
    public class GalleryByIdSpecifications : BaseSpecifications<Media, int>
    {
        public GalleryByIdSpecifications(int id)
            : base(media =>
                media.Id == id &&
                media.Category == MediaCategory.Gallery &&
                !media.IsDeleted)
        {
        }
    }
}
