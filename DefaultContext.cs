using CAD.Models.Setting;
using Dotnet.Models.Enum;
using Dotnet.Models.Generic;
using Dotnet.Models.Identity;
using Dotnet.Utils.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace CAD {

    public class DefaultContext : DbContext {

        private IHttpContextAccessor httpContextAccessor;

        public DefaultContext(DbContextOptions<DefaultContext> options, IHttpContextAccessor httpContextAccessor) : base(options) {
            this.httpContextAccessor = httpContextAccessor;
        }


        public DbSet<Role> Roles;
        public DbSet<User> Users;
        public DbSet<UserRole> UserRoles;

        public DbSet<Category> Categorys;

        // 取得登入者資訊
        public string GetLoginUser() {
            return httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("dbo");
            /*
            modelBuilder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey("UserId")
                .IsRequired();

            modelBuilder.Entity<Role>()
                .HasMany<UserRole>()
                .WithOne(ur => ur.Role)
                .HasForeignKey("RoleId")
                .IsRequired();

            modelBuilder.Entity<UserRole>(userrole => {
                userrole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userrole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
                userrole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            
            
            */

            var userRole = new Role {
                Code = "User",
                Description = "一般使用者",
                Id = Guid.NewGuid().ToString(),
                CreatedUser = "DBO",
                CreatedTime = DateTime.Now,
                ModifiedUser = "DBO",
                ModifiedTime = DateTime.Now
            };
            modelBuilder.Entity<Role>().HasData(userRole);

            var adminRole = new Role {
                Code = "Admin",
                Description = "系統管理員",
                Id = Guid.NewGuid().ToString(),
                CreatedUser = "DBO",
                CreatedTime = DateTime.Now,
                ModifiedUser = "DBO",
                ModifiedTime = DateTime.Now
            };
            modelBuilder.Entity<Role>().HasData(adminRole);


            string password = "123456";
            var samUser = new User {
                Account = "admin",
                Name = "系統管理員",
                Id = Guid.NewGuid().ToString(),
                Password = password,
                PasswordHash = HashUtils.HashPassword(password),
                Status = Status.A.ToString(),
                CreatedUser = "DBO",
                CreatedTime = DateTime.Now,
                ModifiedUser = "DBO",
                ModifiedTime = DateTime.Now
            };
            modelBuilder.Entity<User>().HasData(samUser);

            var kevinUser = new User {
                Account = "user",
                Name = "測試帳號",
                Id = Guid.NewGuid().ToString(),
                Password = password,
                PasswordHash = HashUtils.HashPassword(password),
                Status = Status.A.ToString(),
                CreatedUser = "DBO",
                CreatedTime = DateTime.Now,
                ModifiedUser = "DBO",
                ModifiedTime = DateTime.Now
            };
            modelBuilder.Entity<User>().HasData(kevinUser);


            UserRole userRole1 = new UserRole {
                Id = Guid.NewGuid().ToString(),
                RoleId = userRole.Id,
                UserId = samUser.Id
            };

            UserRole userRole2 = new UserRole {
                Id = Guid.NewGuid().ToString(),
                RoleId = userRole.Id,
                UserId = kevinUser.Id
            };
            modelBuilder.Entity<UserRole>().HasData(userRole1);
            modelBuilder.Entity<UserRole>().HasData(userRole2);
        }
    }
}