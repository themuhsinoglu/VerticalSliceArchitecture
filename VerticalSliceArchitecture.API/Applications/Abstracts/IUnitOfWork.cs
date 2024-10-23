using VerticalSliceArchitecture.API.Domain.Entities;
using VerticalSliceArchitecture.API.Infrastructure.Persistence.Repositories.Base;

namespace VerticalSliceArchitecture.API.Applications.Abstracts
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> CompleteAsync();

        void BeginTransaction();
        void CommitTransaction();
        void RolbackTransaction();

        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : BaseEntity;

        Task<int> ExecuteRawSql(string sql);
    }
}
