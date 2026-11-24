namespace School.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SAveChangesAsync();
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>;

    }

}
