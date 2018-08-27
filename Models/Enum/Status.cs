

using Dotnet.Utils.Enum;
using System.ComponentModel;

namespace Dotnet.Models.Enum {

    [JavaScriptEnum]
    public enum Status {

        [Description("生效")]
        A,

        [Description("失效")]
        C
    }
}
