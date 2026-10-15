using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SAveChangesAsync(CancellationToken cancellationToken = default);
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>;
        
    }
    
}
