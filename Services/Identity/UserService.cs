using CAD;
using Dotnet.Models.Identity;
using Dotnet.Repositories.Generic;
using Dotnet.Repositories.Identity;
using Dotnet.Services.Generic;
using Dotnet.Utils.Common;

namespace Dotnet.Services.Identity {
    public class UserService : GenericService<User> {

        private DefaultContext context;
        private UserRepository repository;

        public UserService(DefaultContext context) {
            this.repository = new UserRepository(context);
            this.context = context;
        }

        public override IGenericRepository<User> GetRepository() {
            return repository;
        }
        
        public override void Insert(User user) {
            user.PasswordHash = HashUtils.HashPassword(user.Password);
            base.Insert(user);

            foreach (string roleId in user.Roles) {
                context.UserRoles.Add(new UserRole(user.Id, roleId));
            }

            context.SaveChanges();
        }

        // 變更密碼需自定義Hash
        public override void Update(User user) {
            user.PasswordHash = HashUtils.HashPassword(user.Password);
            base.Update(user);
        }
    }
}