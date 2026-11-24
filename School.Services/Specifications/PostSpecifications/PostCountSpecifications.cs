using School.Domain.Entities.ContentAndMedia;
using School.Domain.Enums;
using School.Shared.DTOs.PostDTOs;

namespace School.Services.Specifications.PostSpecifications
{
    public class PostCountSpecifications : BaseSpecifications<Post, int>
    {
        public PostCountSpecifications(
            PostType type,
            PostQueryParams queryParams)
            : base(PostSpecificationsHelper.GetCriteria(type, queryParams))
        {
        }
    }
}
