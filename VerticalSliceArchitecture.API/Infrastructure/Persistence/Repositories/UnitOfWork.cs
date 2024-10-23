using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.API.Applications.Abstracts;
using VerticalSliceArchitecture.API.Domain.Entities;
using VerticalSliceArchitecture.API.Infrastructure.Persistence.Contexts;
using VerticalSliceArchitecture.API.Infrastructure.Persistence.Repositories.Base;

namespace VerticalSliceArchitecture.API.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteRawSql(string sql)
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public void RolbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
