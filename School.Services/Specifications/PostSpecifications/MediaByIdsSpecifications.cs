using School.Domain.Entities.ContentAndMedia;

namespace School.Services.Specifications.PostSpecifications
{
    public class MediaByIdsSpecifications : BaseSpecifications<Media, int>
    {
        public MediaByIdsSpecifications(List<int> mediaIds)
            : base(media =>
                mediaIds.Contains(media.Id) &&
                !media.IsDeleted)
        {
        }
    }
}
