using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Contracts;

namespace School.Persistence
{
    internal class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(
            IQueryable<TEntity> entryPoint,
            ISpecifications<TEntity, TKey> specifications
        )
        where TEntity : BaseEntity<TKey>
        {
            var Query = entryPoint; //_dbContext.Orders.Where(o=>o.email==email&&o.Id==id).Include(o=>o.Items).Include(o=>o.DeliveryMethods)

            if (specifications is not null)
            {
                if (specifications.Criteria is not null)
                {
                    Query = Query.Where(specifications.Criteria);
                }

                if (
                    specifications.IncludeExpressions is not null
                    && specifications.IncludeExpressions.Any()
                )
                {
                    Query = specifications.IncludeExpressions.Aggregate(
                        Query,
                        (currentQuery, includeExp) => currentQuery.Include(includeExp)
                    );
                    foreach (var includeString in specifications.IncludeStrings)
                    {
                        Query = Query.Include(includeString);
                    }
                }

                if (specifications.OrderBy is not null)
                {
                    Query = Query.OrderBy(specifications.OrderBy);
                }

                if (specifications.OrderByDescending is not null)
                {
                    Query = Query.OrderByDescending(specifications.OrderByDescending);
                }

                if (specifications.IsPaginated == true)
                {
                    Query = Query.Skip(specifications.Skip).Take(specifications.Take);
                }
            }

            return Query;
        }
    }
}
