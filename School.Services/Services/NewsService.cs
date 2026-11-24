using School.Domain.Contracts;
using School.Domain.Enums;
using School.Services.Abstraction;

namespace School.Services.Services
{
    public class NewsService : PostService, INewsService
    {
        public NewsService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override PostType ContentType =>
            PostType.News;
    }
}
