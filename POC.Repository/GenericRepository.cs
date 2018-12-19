using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POC.Repository
{
    public class GenericRepository<TEntity> : UnitOfWork where TEntity : class
    {
        #region Member Variables

        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        #region Constructor

        public GenericRepository(UnitOfWork unitOfWork)
        {

        }

        #endregion
        public async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null
            )
        {
            IQueryable<TEntity> query = _dbSet;


            return await query.ToListAsync();
        }
    }
}
