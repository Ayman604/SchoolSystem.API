using School.Domain.Entities.ContentAndMedia;

namespace School.Services.Specifications.PostSpecifications
{
    public class MediaByIdsSpecifications
    : BaseSpecifications<Media, int>
    {
        public MediaByIdsSpecifications(
            List<int> mediaIds,
            int? currentPostId = null)
            : base(media =>
                mediaIds.Contains(media.Id) &&
                !media.IsDeleted &&
                (
                    media.PostAttachment == null ||
                    (currentPostId != null &&
                     media.PostAttachment.PostId == currentPostId)
                ))
        {
        }
    }
}
