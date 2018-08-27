using CAD;
using Dotnet.Models.Identity;
using Dotnet.Repositories.Generic;

namespace Dotnet.Repositories.Identity {
    public class UserRepository : GenericRepository<User>, IGenericRepository<User> {

        private readonly DefaultContext context;

        public UserRepository(DefaultContext context) : base(context) {
            this.context = context;
        }
    }
}