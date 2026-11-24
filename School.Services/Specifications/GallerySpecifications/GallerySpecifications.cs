using School.Domain.Entities.ContentAndMedia;
using School.Shared;

namespace School.Services.Specifications.GallerySpecifications
{
    public class GallerySpecifications : BaseSpecifications<Media, int>
    {
        public GallerySpecifications(GalleryQueryParams queryParams)
            : base(GallerySpecificationsHelper.GetCriteria(queryParams))
        {
            switch (queryParams.Sort)
            {
                case GallerySortingOptions.Oldest:
                    AddOrderBy(media => media.Id);
                    break;

                case GallerySortingOptions.NameAsc:
                    AddOrderBy(media => media.FileName);
                    break;

                case GallerySortingOptions.NameDesc:
                    AddOrderByDescending(media => media.FileName);
                    break;

                default:
                    AddOrderByDescending(media => media.Id);
                    break;
            }

            ApplyPagination(
                queryParams.PageSize,
                queryParams.PageIndex);
        }
    }
}
