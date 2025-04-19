using Microsoft.EntityFrameworkCore;
using TeamDebugger.Data;
using TeamDebugger.Services;

namespace TeamDebugger.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected DataContext _context;
        protected DbSet<T> _dbSet;
        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public DbSet<T> Table => _dbSet;

        public T Get(object id)
        {
            return _dbSet.Find(id);
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public ErrorCode Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (DbUpdateException ex) when (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 2627)
            {
                Console.WriteLine(ex.Message);
                return ErrorCode.Duplicate;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                return ErrorCode.Error;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return ErrorCode.Error;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ErrorCode.Error;
            }
        }
        public ErrorCode Update(object id, T entity)
        {
            try
            {
                var obj = Get(id);
                _context.Entry(obj).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ErrorCode.Error;
            }

        }
        public ErrorCode Delete(object id)
        {
            try
            {
                var obj = Get(id);
                _dbSet.Remove(obj);
                _context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ErrorCode.Error;
            }
        }
    }
}
