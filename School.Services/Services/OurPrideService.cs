using School.Domain.Contracts;
using School.Domain.Enums;
using School.Services.Abstraction;

namespace School.Services.Services
{
    public class OurPrideService : PostService, IOurPrideService
    {
        public OurPrideService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override PostType ContentType =>
            PostType.OurPride;
    }
}
