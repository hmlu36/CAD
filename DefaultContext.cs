using CAD.Models.Setting;
using Dotnet.Models.Generic;
using Dotnet.Utils.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CAD {

    public class DefaultContext : DbContext {

        private IHttpContextAccessor httpContextAccessor;

        public DefaultContext(DbContextOptions<DefaultContext> options, IHttpContextAccessor httpContextAccessor) : base(options) {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Lesson> Lessons;
        public DbSet<TeachingAid> TeachingAids;

        // 取得登入者資訊
        public string GetLoginUser() {
            //return httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return "dbo";
        }

        /// <summary>
        ///　新增/編輯時, 初始Auditable欄位
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges() {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is GenericEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries) {
                GenericEntity entity = entry.Entity as GenericEntity;
                // LogTo.Debug("entity is null:" + (entity == null) + ", entity:" + entity);
                if (entity != null) {
                    // 參考: https://stackoverflow.com/questions/36641338/how-get-current-user-in-asp-net-core/36641907
                    string identityName = GetLoginUser();// httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added) {
                        entity.CreatedUser = identityName;
                        entity.CreatedTime = now;
                    } else {
                        base.Entry(entity).Property(x => x.CreatedUser).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedTime).IsModified = false;
                    }

                    entity.ModifiedUser = identityName;
                    entity.ModifiedTime = now;
                }
            }

            return base.SaveChanges();
        }


        /*
        /// <summary>
        /// 印出Entity Framework 的query SQL
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
        */


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}