using CAD;
using Dotnet.Models.Identity;
using Dotnet.Repositories.Generic;
using Dotnet.Repositories.Identity;
using Dotnet.Services.Generic;

namespace Dotnet.Services.Identity {
    
    public class RoleService : GenericService<Role> {

        private RoleRepository repository;

        public RoleService(DefaultContext context) {

            this.repository = new RoleRepository(context);
        }

        public override IGenericRepository<Role> GetRepository() {

            return repository;
        }
    }
}