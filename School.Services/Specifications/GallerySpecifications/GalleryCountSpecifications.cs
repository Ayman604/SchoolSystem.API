using School.Domain.Entities.ContentAndMedia;
using School.Shared;

namespace School.Services.Specifications.GallerySpecifications
{
    public class GalleryCountSpecifications : BaseSpecifications<Media, int>
    {
        public GalleryCountSpecifications(GalleryQueryParams queryParams)
            : base(GallerySpecificationsHelper.GetCriteria(queryParams))
        {
        }
    }
}

