using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Globant.StandardArchitecture.Infrastructure.Persistence
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(DbContext context)
        {
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = dbContext.Set<T>();
        }

        /// <summary>
        /// Adicionar um  registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Adicionar vários registros
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Atualizar um registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Remover um registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Buscar por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T?> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <summary>
        /// Buscar todos os registros
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }


        /// <summary>
        /// Buscar registros com filtro
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
    }
}
