using CAD;
using CAD.Models.Setting;
using Dotnet.Repositories.Generic;

namespace Dotnet.Repositories.Identity {
    public class TeachingAidRepository : GenericRepository<TeachingAid>, IGenericRepository<TeachingAid> {

        private readonly DefaultContext context;

        public TeachingAidRepository(DefaultContext context) : base(context) {
            this.context = context;
        }
    }
}