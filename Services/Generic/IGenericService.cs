using Dotnet.Utils.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dotnet.Services.Generic {
    public interface IGenericService<T> where T : class {
        void Insert(T entity);

        void Update(T entity);

        void Delete(string id);

        T GetById(string id);

        T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>>[] includes = null);

        int Count();

        PagedResult<T> Query(Expression<Func<T, bool>> filter, int pageNumber);
    }
}