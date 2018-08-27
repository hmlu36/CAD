using CAD;
using Dotnet.Models.Identity;
using Dotnet.Repositories.Generic;

namespace Dotnet.Repositories.Identity {
    public class RoleRepository : GenericRepository<Role>, IGenericRepository<Role> {

        private readonly DefaultContext context;

        public RoleRepository(DefaultContext context) : base(context) {
            this.context = context;
        }
    }
}