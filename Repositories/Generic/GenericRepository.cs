using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Anotar.Log4Net;
using CAD;
using Dotnet.Models.Generic;
using Dotnet.Utils.Common;
using Dotnet.Utils.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dotnet.Repositories.Generic {
    public class GenericRepository<T> : IGenericRepository<T> where T : GenericEntity {

        private readonly DefaultContext context;

        private readonly DbSet<T> dbSet;

        private IQueryable<T> query;

        public GenericRepository(DefaultContext context) {

            this.context = context;
            this.dbSet = context.Set<T>();
            this.query = dbSet.AsTracking();
        }

        public void Insert(T entity) {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        // 參考: https://blog.johnwu.cc/article/ironman-day24-asp-net-core-entity-framework-core.html
        public void Update(T entity) {

            // 先用Id取資料再做更新
            var dbEntity = this.FindById(entity.Id);
            if (dbEntity != null) {
                UpdateChildren(dbEntity, entity);
                context.Entry(dbEntity).CurrentValues.SetValues(entity);

                context.SaveChanges();
            } else {
                throw new KeyNotFoundException("entity: " + entity + " Key: " + entity.Id + " Not Found!");
            }
        }

        private void UpdateChildren(T dbEntity, T entity) {

            // 對Children做更新
            // 取得型態為List，並且不為空
            var properties = entity.GetType().GetProperties().Where(property => typeof(IList).IsAssignableFrom(property.PropertyType) && property.GetValue(entity) != null);
            LogTo.Debug("children count:" + properties.Count());
            foreach (var property in properties) {
                //LogTo.Debug("property type:" + property.PropertyType.Name + ", compare:" + typeof(IList).IsAssignableFrom(property.PropertyType) + ", db value:" + property.GetValue(dbEntity) + ", form value:" + property.GetValue(entity));
                var dbChildrenEntrys = (IEnumerable<object>)property.GetValue(dbEntity);
                var formChildrenEntrys = (IEnumerable<object>)property.GetValue(entity);

                // 移除不存在Children
                foreach (var dbChildrenEntry in dbChildrenEntrys) {
                    if (!formChildrenEntrys.Any(tempEntry => !StringUtils.TrimIsNull(((IEntity)tempEntry).Id) && ((IEntity)tempEntry).Id.Equals(((IEntity)dbChildrenEntry).Id))) {
                        //LogTo.Debug("Children Remove");
                        context.Remove(dbChildrenEntry);
                    }
                }

                // 新增或更新Children
                foreach (var childrenEntry in formChildrenEntrys) {
                    if (StringUtils.TrimIsNull(((IEntity)childrenEntry).Id)) {
                        // LogTo.Debug("Children Add");
                        context.Add(childrenEntry);
                    } else {
                        var dbChildrenEntry = dbChildrenEntrys.Where(tempEntry => ((IEntity)tempEntry).Id.Equals(((IEntity)childrenEntry).Id)).FirstOrDefault();
                        if (dbChildrenEntry != null) {
                            // LogTo.Debug("Children Update");
                            context.Entry(dbChildrenEntry).CurrentValues.SetValues(childrenEntry);
                        }
                    }
                }
            }
        }

        public void Delete(string id) {

            var dbEntity = this.FindById(id);
            if (dbEntity != null) {
                dbSet.Remove(dbEntity);
            } else {
                throw new KeyNotFoundException("entity: " + dbEntity + " Key: " + dbEntity.Id + " Not Found!");
            }
            context.SaveChanges();
        }

        // 預設會取出所有Children
        public T FindById(string id) {

            return dbSet.Include(context.GetIncludePaths(typeof(T))).SingleOrDefault(entry => entry.Id.Equals(id));
        }

        public T Find(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>>[] includes = null) {

            if (includes != null) {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }
            return query.Where(filter).SingleOrDefault();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>>[] includes = null) {

            if (includes != null) {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }

            if (filter != null) {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public int Count() {

            return dbSet.Count();
        }

        public PagedResult<T> Query(Expression<Func<T, bool>> filter = null, int pageNumber = 1) {
            return query.Where(filter).GetPaged(pageNumber);
        }
    }

    /// <summary>
    /// Entity Framework Core 2.0.1 Eager Loading on all nested related entities
    /// 參考: https://stackoverflow.com/questions/49593482/entity-framework-core-2-0-1-eager-loading-on-all-nested-related-entities
    /// </summary>
    public static partial class CustomExtensions {

        public static IQueryable<T> Include<T>(this IQueryable<T> source, IEnumerable<string> navigationPropertyPaths) where T : class {

            return navigationPropertyPaths.Aggregate(source, (query, path) => query.Include(path));
        }

        public static IEnumerable<string> GetIncludePaths(this DbContext context, Type clrEntityType) {

            var entityType = context.Model.FindEntityType(clrEntityType);
            var includedNavigations = new HashSet<INavigation>();
            var stack = new Stack<IEnumerator<INavigation>>();
            while (true) {
                var entityNavigations = new List<INavigation>();
                foreach (var navigation in entityType.GetNavigations()) {
                    if (includedNavigations.Add(navigation))
                        entityNavigations.Add(navigation);
                }
                if (entityNavigations.Count == 0) {
                    if (stack.Count > 0)
                        yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
                } else {
                    foreach (var navigation in entityNavigations) {
                        var inverseNavigation = navigation.FindInverse();
                        if (inverseNavigation != null)
                            includedNavigations.Add(inverseNavigation);
                    }
                    stack.Push(entityNavigations.GetEnumerator());
                }
                while (stack.Count > 0 && !stack.Peek().MoveNext())
                    stack.Pop();
                if (stack.Count == 0)
                    break;
                entityType = stack.Peek().Current.GetTargetType();
            }
        }
    }
}