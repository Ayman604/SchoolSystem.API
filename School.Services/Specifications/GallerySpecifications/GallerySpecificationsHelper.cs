using School.Domain.Entities.ContentAndMedia;
using School.Domain.Enums;
using School.Shared;
using System.Linq.Expressions;

namespace School.Services.Specifications.GallerySpecifications
{
    internal static class GallerySpecificationsHelper
    {
        public static Expression<Func<Media, bool>> GetCriteria(
            GalleryQueryParams queryParams)
        {
            return media =>
                media.Category == MediaCategory.Gallery &&
                !media.IsDeleted &&
                (queryParams.Type == null ||
                 media.Type == queryParams.Type) &&
                (string.IsNullOrWhiteSpace(queryParams.Search) ||
                 media.FileName.Contains(queryParams.Search) ||
                 media.AltText.Contains(queryParams.Search));
        }
    }
}
