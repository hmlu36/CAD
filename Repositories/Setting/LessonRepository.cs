using CAD;
using CAD.Models.Setting;
using Dotnet.Repositories.Generic;

namespace Dotnet.Repositories.Identity {
    public class LessonRepository : GenericRepository<Lesson>, IGenericRepository<Lesson> {

        private readonly DefaultContext context;

        public LessonRepository(DefaultContext context) : base(context) {
            this.context = context;
        }
    }
}