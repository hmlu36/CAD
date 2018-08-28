using CAD;
using CAD.Models.Setting;
using Dotnet.Repositories.Generic;

namespace Dotnet.Repositories.Identity {
    public class CategoryRepository : GenericRepository<Category>, IGenericRepository<Category> {

        private readonly DefaultContext context;

        public CategoryRepository(DefaultContext context) : base(context) {
            this.context = context;
        }
    }
}