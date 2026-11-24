using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Contracts;
using School.Persistence.Data.DbContexts;

namespace School.Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey>
        : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly SchoolDbContext _dbContext;

        public GenericRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
         => await _dbContext.Set<TEntity>().AddAsync(entity);


        public void Delete(TEntity entity)
        => _dbContext.Set<TEntity>().Remove(entity);


        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(TKey Id)
              => await _dbContext.Set<TEntity>().FindAsync(Id);

        public void Update(TEntity entity)
        => _dbContext.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(
    ISpecifications<TEntity, TKey> specifications)
        {
            var query = SpecificationEvaluator.CreateQuery(
                _dbContext.Set<TEntity>(),
                specifications);

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(
            ISpecifications<TEntity, TKey> specifications)
        {
            var query = SpecificationEvaluator.CreateQuery(
                _dbContext.Set<TEntity>(),
                specifications);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(
            ISpecifications<TEntity, TKey> specifications)
        {
            return await SpecificationEvaluator
                .CreateQuery(_dbContext.Set<TEntity>(), specifications)
                .CountAsync();
        }
    }
}
