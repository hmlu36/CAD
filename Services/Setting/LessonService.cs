using CAD;
using CAD.Models.Setting;
using Dotnet.Repositories.Generic;
using Dotnet.Repositories.Identity;
using Dotnet.Services.Generic;

namespace Dotnet.Services.Identity {
    
    public class LessonService : GenericService<Lesson> {

        private LessonRepository repository;

        public LessonService(DefaultContext context) {

            this.repository = new LessonRepository(context);
        }

        public override IGenericRepository<Lesson> GetRepository() {

            return repository;
        }
    }
}