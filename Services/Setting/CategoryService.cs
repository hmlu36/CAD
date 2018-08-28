using CAD;
using CAD.Models.Setting;
using Dotnet.Repositories.Generic;
using Dotnet.Repositories.Identity;
using Dotnet.Services.Generic;

namespace Dotnet.Services.Identity {
    
    public class CategoryService : GenericService<Category> {

        private CategoryRepository repository;

        public CategoryService(DefaultContext context) {

            this.repository = new CategoryRepository(context);
        }

        public override IGenericRepository<Category> GetRepository() {

            return repository;
        }
    }
}