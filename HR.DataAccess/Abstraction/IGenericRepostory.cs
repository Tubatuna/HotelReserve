using HR.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Abstraction
{
    public interface IGenericRepostory <T> where T : class, new()  
    {
        void Add(T entity); 
        void Update(T entity);  
        void Delete(T entity);
        T GetByID(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

    }
}
