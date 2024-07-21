using HR.DataAccess.Abstraction;
using HR.DataAccess.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Repostories
{
    public class GenericRepostory<T> : IGenericRepostory<T> where T : class, new()
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepostory(Context context)
        {
            _context = context;
            _dbSet= context.Set<T>();
        }

        public void Add(T entity)
        {
           _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
        }

        public T GetByID(Expression<Func<T, bool>> filter)
        {

            return _dbSet.FirstOrDefault(filter);
        }

        public void Update(T entity)
        {
            _context.SaveChanges();
        }
    }
}
