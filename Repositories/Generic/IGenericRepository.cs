using Dotnet.Utils.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dotnet.Repositories.Generic {

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 參考寫法 http://www.janholinka.net/Blog/Article/9 
    public interface IGenericRepository<T> where T : class {
        void Insert(T entity);

        void Update(T entity);

        void Delete(string id);

        T FindById(string id);

        T Find(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>>[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>>[] includes = null);

        int Count();

        PagedResult<T> Query(Expression<Func<T, bool>> filter = null, int pageNumber = 1);
    }
}