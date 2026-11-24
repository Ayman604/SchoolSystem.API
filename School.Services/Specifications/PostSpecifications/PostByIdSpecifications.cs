using School.Domain.Entities.ContentAndMedia;
using School.Domain.Enums;

namespace School.Services.Specifications.PostSpecifications
{
    public class PostByIdSpecifications : BaseSpecifications<Post, int>
    {
        public PostByIdSpecifications(int id, PostType type)
            : base(post =>
                post.Id == id &&
                post.Type == type)
        {
            AddInclude("MediaAttachments.Media");
        }
    }
}
