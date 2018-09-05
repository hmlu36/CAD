using CAD;
using CAD.Models.Setting;
using Dotnet.Repositories.Generic;
using Dotnet.Repositories.Identity;
using Dotnet.Services.Generic;

namespace Dotnet.Services.Identity {
    
    public class TeachingAidService : GenericService<TeachingAid> {

        private TeachingAidRepository repository;

        public TeachingAidService(DefaultContext context) {

            this.repository = new TeachingAidRepository(context);
        }

        public override IGenericRepository<TeachingAid> GetRepository() {

            return repository;
        }
    }
}