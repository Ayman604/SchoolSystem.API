using School.Domain.Entities.ContentAndMedia;
using School.Domain.Enums;
using School.Shared.DTOs.PostDTOs;
using System.Linq.Expressions;

namespace School.Services.Specifications.PostSpecifications
{
    internal static class PostSpecificationsHelper
    {
        public static Expression<Func<Post, bool>> GetCriteria(
            PostType type,
            PostQueryParams queryParams)
        {
            return post =>
                post.Type == type &&
                (queryParams.IsPublished == null ||
                 post.IsPublished == queryParams.IsPublished) &&
                (string.IsNullOrWhiteSpace(queryParams.Search) ||
                 post.Title.Contains(queryParams.Search) ||
                 post.Content.Contains(queryParams.Search));
        }
    }

    public class PostSpecifications : BaseSpecifications<Post, int>
    {
        public PostSpecifications(
            PostType type,
            PostQueryParams queryParams)
            : base(PostSpecificationsHelper.GetCriteria(type, queryParams))
        {
            AddInclude("MediaAttachments.Media");

            switch (queryParams.Sort)
            {
                case PostSortingOptions.Oldest:
                    AddOrderBy(p => p.Id);
                    break;

                case PostSortingOptions.TitleAsc:
                    AddOrderBy(p => p.Title);
                    break;

                case PostSortingOptions.TitleDesc:
                    AddOrderByDescending(p => p.Title);
                    break;

                default:
                    AddOrderByDescending(p => p.Id);
                    break;
            }

            ApplyPagination(
                queryParams.PageSize,
                queryParams.PageIndex);
        }
    }
}
