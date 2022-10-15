using Microsoft.EntityFrameworkCore;
using UserHub.Repositories.Interfaces;

namespace UserHub.Repositories.Implementations
{
    //Generic Repository and Its implementations.
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;
        // constructor injection
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // set - we are uing to set entity type
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
        }

        public TEntity Find(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
