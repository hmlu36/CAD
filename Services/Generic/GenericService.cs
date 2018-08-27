using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dotnet.Repositories.Generic;
using Dotnet.Utils.Paging;

namespace Dotnet.Services.Generic {
    public abstract class GenericService<T> : IGenericService<T> where T : class {

        public abstract IGenericRepository<T> GetRepository();

        public int Count() {

            return GetRepository().Count();
        }

        public virtual void Insert(T entity) {

            GetRepository().Insert(entity);
        }

        public virtual void Update(T entity) {

            GetRepository().Update(entity);
        }

        public virtual void Delete(string id) {

            GetRepository().Delete(id);
        }

        public T GetById(string id) {
            return GetRepository().FindById(id);
        }

        public T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes) {

            return GetRepository().Find(filter, includes);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>>[] includes = null) {

            return GetRepository().FindAll(filter, includes);
        }


        public PagedResult<T> Query(Expression<Func<T, bool>> filter, int pageNumber) {

            return GetRepository().Query(filter, pageNumber);
        }
    }
}