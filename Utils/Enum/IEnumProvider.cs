using System;
using System.Collections.Generic;

namespace Dotnet.Utils.Enum
{
    public interface IEnumProvider {
        IEnumerable<Type> GetEnumTypes();
    }
}
